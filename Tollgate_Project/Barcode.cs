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
    internal class Barcode
    {
        public void SearchBarcode(string barcode)
        {
            try
            {
                MySqlConnection con = new MySqlConnection();
                con = ConnectionString.awsconnectionstring;
                System.Data.DataTable dt = new System.Data.DataTable();
                MySqlCommand cmd = new MySqlCommand("Select * from Barcode where barcode='" + barcode + "'", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("ValidBarcode");
                }
                else
                {
                    MessageBox.Show("Invalid barcode");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
