using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tollgate_Project
{
    public partial class Adminpassword : Form
    {
        public Adminpassword()
        {
            InitializeComponent();
           
        }

        private void Adminpassword_Leave(object sender, EventArgs e)
        {
           
        }

        private void Adminpassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string password = "";
            if (tbx_password.Text == "") MessageBox.Show("Please Enter password");
            SqlConnection con = new SqlConnection();
            con = ConnectionString.localconnectionstring;
            string cmd_login = @"select password from Admin ";
            try
            {

                con.Open();

                SqlCommand cmd = new SqlCommand(cmd_login, con);
                //cmd.Parameters.Add(new SqlParameter("@password",tbx_password.Text));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                password = Convert.ToString(dt.Rows[0]["password"]);
                con.Close();
                if (password == tbx_password.Text)
                {
                    Amountsetting ast = new Amountsetting();
                    ast.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong Password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbx_password_Enter(object sender, EventArgs e)
        {
        
             try
             {
                 System.Diagnostics.Process.Start("osk.exe");
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
        }

        private void tbx_password_Leave(object sender, EventArgs e)
        {
            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("osk"))
            {
                process.Kill();
            }
        }

        private void tbx_password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
