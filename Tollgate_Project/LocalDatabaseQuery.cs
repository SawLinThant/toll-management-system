using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tollgate_Project
{
    internal class LocalDatabaseQuery
    {
        public void Addtolocaldatabase(int classes, string from, string to, string license, string gateid, string laneid, string imagepath)
        {
            // int ID = Autogenerateid();
            int fee = Getamount(classes, from, to);
            Guid myuuid = Guid.NewGuid();
            //  int exampleFee = 200;
            SqlConnection con = new SqlConnection();
            con = ConnectionString.localconnectionstring;
            string cmd_addrecord = @"insert into record (Id,license,class,gateid,dirFrom,dirTo,charge,timedate,laneid,imagepath)
                                                      values(@id,@License,@Class,@Gateid,@DirFrom,@DirTo,@Charge,@TimeDate,@LaneID,@Imagepath)";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(cmd_addrecord, con);
                cmd.Parameters.Add(new SqlParameter("@id", myuuid));
                cmd.Parameters.Add(new SqlParameter("@License", license));
                cmd.Parameters.Add(new SqlParameter("@Class", classes));
                cmd.Parameters.Add(new SqlParameter("@Gateid", gateid));
                cmd.Parameters.Add(new SqlParameter("@DirFrom", from));
                cmd.Parameters.Add(new SqlParameter("@DirTo", to));
                cmd.Parameters.Add(new SqlParameter("@Charge", fee));
                cmd.Parameters.Add(new SqlParameter("@TimeDate", DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("@LaneID", laneid));
                cmd.Parameters.Add(new SqlParameter("@Imagepath", imagepath));
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

        public int Getamount(int classes, string from, string to)
        {
            SqlConnection con = new SqlConnection();
            con = ConnectionString.localconnectionstring;
            string cmd_getamount = @"select charge from amount where class='" + classes + "' and dirFrom='" + from + "' and dirTo='" + to + "'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(cmd_getamount, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
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

        public string Getimagepath(string license, string timedate)
        {
            SqlConnection con = new SqlConnection();
            con = ConnectionString.localconnectionstring;
            string cmd_getimagepath = "select imagepath from Record where license=@License and timedate=@TimeDate";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(cmd_getimagepath, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
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

            SqlConnection con = new SqlConnection();
            con = ConnectionString.localconnectionstring;
            string cmd_getimagepath = "select class from car_detail where license=@License";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(cmd_getimagepath, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.Add(new SqlParameter("@License", license));
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

            SqlConnection con = new SqlConnection();
            con = ConnectionString.localconnectionstring;
            string cmd_getimagepath = "select license from car_detail where license=@License";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(cmd_getimagepath, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.Add(new SqlParameter("@License", license));
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
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
            SqlConnection con = new SqlConnection();
            con = ConnectionString.localconnectionstring;
            string cmd_addrecord = @"insert into car_detail (Id,license,class)
                                                      values(@id,@License,@Class)";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(cmd_addrecord, con);
                cmd.Parameters.Add(new SqlParameter("@id", myuuid));
                cmd.Parameters.Add(new SqlParameter("@License", license));
                cmd.Parameters.Add(new SqlParameter("@Class", classes));

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

        public void addbarcode(string qrcode)
        {
            SqlConnection con = new SqlConnection();
            con = ConnectionString.localconnectionstring;
            string cmd_addrecord = @"insert into Barcode (barcode_id)
                                                      values(@Barcodes)";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(cmd_addrecord, con);
                cmd.Parameters.Add(new SqlParameter("@Barcodes", qrcode));
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

        public void FreeChargedCars(int classes, string from, string to, string license, string gateid, string laneid, string imagepath)
        {
            // int ID = Autogenerateid();
            int fee = 0;
            Guid myuuid = Guid.NewGuid();
            //  int exampleFee = 200;
            SqlConnection con = new SqlConnection();
            con = ConnectionString.localconnectionstring;
            string cmd_addrecord = @"insert into record (Id,license,class,gateid,dirFrom,dirTo,charge,timedate,laneid,imagepath)
                                                      values(@id,@License,@Class,@Gateid,@DirFrom,@DirTo,@Charge,@TimeDate,@LaneID,@Imagepath)";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(cmd_addrecord, con);
                cmd.Parameters.Add(new SqlParameter("@id", myuuid));
                cmd.Parameters.Add(new SqlParameter("@License", license));
                cmd.Parameters.Add(new SqlParameter("@Class", classes));
                cmd.Parameters.Add(new SqlParameter("@Gateid", gateid));
                cmd.Parameters.Add(new SqlParameter("@DirFrom", from));
                cmd.Parameters.Add(new SqlParameter("@DirTo", to));
                cmd.Parameters.Add(new SqlParameter("@Charge", fee));
                cmd.Parameters.Add(new SqlParameter("@TimeDate", DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("@LaneID", laneid));
                cmd.Parameters.Add(new SqlParameter("@Imagepath", imagepath));
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
    }
}
