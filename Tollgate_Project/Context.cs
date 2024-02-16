using Amazon.S3.Model;
using Amazon.S3;
using MySql.Data.MySqlClient;
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
using Amazon;

namespace Tollgate_Project
{
    internal class Context
    {
     
        public int AWSautogenerateid()
        {
            int id = 0;
            MySqlConnection con = new MySqlConnection();
            con = ConnectionString.awsconnectionstring;
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"select * from Record", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    id = 1;
                }
                else
                {
                    id = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0]);
                    id++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return id;
        }

        #region barcode
        public void addbarcode(string qrcode)
        {
            MySqlConnection con = new MySqlConnection();
            con = ConnectionString.connectionstring;
            string cmd_addrecord = @"insert into barcode (barcode_id)
                                                      values(@Barcodes)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(cmd_addrecord, con);
                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("@Barcodes", qrcode));
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        #endregion

        public int Getamount(int classes, string from, string to)
        {

            MySqlConnection con = new MySqlConnection();
            con = ConnectionString.connectionstring;
            string cmd_getamount = @"select charge from amount where class='" + classes + "' and dirfrom='" + from + "' and dirto='" + to + "'";

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(cmd_getamount, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);


                return Convert.ToInt32(dt.Rows[0][0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public void Addtolocaldatabase(int classes, string from, string to, string license, string gateid, string laneid,string imagepath)
        {
            // int ID = Autogenerateid();
              int fee = Getamount(classes, from, to);
            Guid myuuid = Guid.NewGuid();
          //  int exampleFee = 200;
            MySqlConnection con = new MySqlConnection();
            con = ConnectionString.connectionstring;
            string cmd_addrecord = @"insert into record (Id,license,class,gateid,dirFrom,dirTo,charge,timedate,laneid,imagepath)
                                                      values(@id,@License,@Class,@Gateid,@DirFrom,@DirTo,@Charge,@TimeDate,@LaneID,@Imagepath)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(cmd_addrecord, con);
                  cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("@id", myuuid));
                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("@License", license));
                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("@Class", classes));
                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("@Gateid", gateid));
                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("@DirFrom", from));
                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("@DirTo", to));
                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("@Charge", fee));
                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("@TimeDate", DateTime.Now));
                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("@LaneID", laneid));
                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("@Imagepath", imagepath));
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public string Getimagepath(string license, string timedate)
        {
            MySqlConnection con = new MySqlConnection();
            con = ConnectionString.connectionstring;
            string cmd_getimagepath = "select imagepath from Record where license=@License and timedate=@TimeDate";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(cmd_getimagepath, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                cmd.Parameters.Add(new SqlParameter("@License", license));
                cmd.Parameters.Add(new SqlParameter("@TimeDate", timedate));
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);


                return Convert.ToString(dt.Rows[0][0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public string GetCarDetail(string license)
        {

            MySqlConnection con = new MySqlConnection();
            con = ConnectionString.connectionstring;
            string cmd_getimagepath = "select class from car_detail where license=@License";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(cmd_getimagepath, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                cmd.Parameters.Add(new MySqlParameter("@License", license));
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                return Convert.ToString(dt.Rows[0][0]);
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Unregistered Car");
                return "Unregistered Car";
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public bool IsCarExist(string license)
        {

            MySqlConnection con = new MySqlConnection();
            con = ConnectionString.connectionstring;
            string cmd_getimagepath = "select license from car_detail where license=@License";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(cmd_getimagepath, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                cmd.Parameters.Add(new MySqlParameter("@License", license));
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                if(dt.Rows.Count>0)
                {
                    return true;
                }
                else { return false; }
                
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Unregistered Car");
                return false;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public void AddtoCarDetail(string classes, string license)
        {
            Guid myuuid = Guid.NewGuid();
            MySqlConnection con = new MySqlConnection();
            con = ConnectionString.connectionstring;
            string cmd_addrecord = @"insert into car_detail (Id,license,class)
                                                      values(@id,@License,@Class)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(cmd_addrecord, con);
                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("@id", myuuid));
                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("@License", license));
                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("@Class", classes));
               
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public async void uploadS3(string picUrl, string keyName = "")
        {
            RegionEndpoint region = RegionEndpoint.GetBySystemName("ap-southeast-1");
            IAmazonS3 client = new AmazonS3Client("AKIA2URURO2QMSBXZFQV", "d+0JZxKfdnVPBMQ4oloBLnkTMHX7KeYr/ct5WtVc", region);

            string bucketname = "tollgate-upload";
            //string keyName = "license/testing";
            //string filePath = @"C:\Users\User\Pictures\TollCaptureLic_1D479320240129111915485Pic.jpg";

            var request = new PutObjectRequest
            {
                BucketName = bucketname,
                Key = keyName,
                FilePath = picUrl,
            };
            var response = await client.PutObjectAsync(request);
            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                //MessageBox.Show("file upload complete");

            }
            else
            {
                MessageBox.Show("file upload fail");
            }
        }
    }
}
