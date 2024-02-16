using Amazon.RDSDataService;
using Amazon.RDSDataService.Model;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using onvif.services;
using Ozeki.VoIP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tollgate_Project
{
    internal class AWSsync
    {
        MySqlConnection localconnection = ConnectionString.connectionstring;
        MySqlConnection awsconnection = ConnectionString.awsconnectionstring;
        string mylocalconnectionstring = $"server={Properties.Settings.Default.dbservername};uid={Properties.Settings.Default.dbuserid};pwd={Properties.Settings.Default.dbpassword};database={Properties.Settings.Default.dbname};";
        string mycloudconnectionstring = $"server={Properties.Settings.Default.cloudservername};uid={Properties.Settings.Default.clouddbuserid};pwd={Properties.Settings.Default.clouddbpassword};database={Properties.Settings.Default.clouddbname};";    

        public void SyncMySqlData()
        {
            using (MySqlConnection localconnectionstring = new MySqlConnection(mylocalconnectionstring)) 
            using(MySqlConnection cloudconnectionstring=new MySqlConnection(mycloudconnectionstring))
            {
                try
                {
                    localconnectionstring.Open();
                    cloudconnectionstring.Open();
                    DataTable localtable=GetLocalData(localconnectionstring); // Step 1: Retrieve data from the local database
                    DataTable nonExistingRecord = GetNonExixtingRecord(cloudconnectionstring, localtable);// Step 2: Compare and filter records
                    InsertRecordIntoCloud(nonExistingRecord, cloudconnectionstring);
                    MessageBox.Show("Sync successful");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    localconnectionstring.Close();
                    cloudconnectionstring.Close();
                }
            }
        }

        static DataTable GetLocalData(MySqlConnection connection)
        {
            string query = "select * from record";
            MySqlCommand cmd=new MySqlCommand(query, connection);
            using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
            {
                DataTable dt=new DataTable();
                da.Fill(dt);
                return dt;
            }

        }

        static bool RecordExistInCloudDatabase(string uid, MySqlConnection connection)
        {
            string query = "select count(*) from record where Id=@UID";
            MySqlCommand cmd = new MySqlCommand(query,connection);
            cmd.Parameters.Add(new MySqlParameter("@UID", uid));
            int count=Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }

        static DataTable GetNonExixtingRecord(MySqlConnection connection, DataTable localtable)
        {
            DataTable nonExistingRecord = localtable.Clone(); // Create an empty DataTable with the same structure

            foreach (DataRow localRow in localtable.Rows)
            {
                string uid = Convert.ToString(localRow["Id"]);
                if (!RecordExistInCloudDatabase(uid, connection))
                {
                    // Add the row to the nonExistingRecord DataTable
                    DataRow newRow = nonExistingRecord.NewRow();
                    newRow.ItemArray = localRow.ItemArray;
                    nonExistingRecord.Rows.Add(newRow);
                }
            }

            return nonExistingRecord;
        }

        static void InsertRecordIntoCloud(DataTable NonExistingRecord, MySqlConnection connection)
        {
            if (NonExistingRecord.Rows.Count > 0)
            {
                string query = @"insert into record(Id, license,class,gateid,dirFrom,dirTo,charge,timedate,laneid,imagepath)
                                          values(@id, @License, @Class, @Gateid, @DirFrom, @DirTo, @Charge, @TimeDate, @LaneID, @Imagepath)";

                using (MySqlDataAdapter da = new MySqlDataAdapter())
                {
                    foreach (DataRow row in NonExistingRecord.Rows)
                    {
                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.Add(new MySqlParameter("@id", row["Id"]));
                            cmd.Parameters.Add(new MySqlParameter("@License", row["license"]));
                            cmd.Parameters.Add(new MySqlParameter("@Class", row["class"]));
                            cmd.Parameters.Add(new MySqlParameter("@Gateid", row["gateid"]));
                            cmd.Parameters.Add(new MySqlParameter("@DirFrom", row["dirFrom"]));
                            cmd.Parameters.Add(new MySqlParameter("@DirTo", row["dirTo"]));
                            cmd.Parameters.Add(new MySqlParameter("@Charge", row["charge"]));
                            cmd.Parameters.Add(new MySqlParameter("@TimeDate", row["timedate"]));
                            cmd.Parameters.Add(new MySqlParameter("@LaneID", row["laneid"]));
                            cmd.Parameters.Add(new MySqlParameter("@Imagepath", row["imagepath"]));

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}
