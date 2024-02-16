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
    public partial class Amountsetting : Form
    {
        public Amountsetting()
        {
            InitializeComponent();
            DisplayGrid();
            AddBtnToGrid();
        }

        private void AddBtnToGrid()
        {
            DataGridViewButtonColumn addbuttonColumn = new DataGridViewButtonColumn();
            addbuttonColumn.HeaderText = "Edit";
            addbuttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Insert(4, addbuttonColumn);
            addbuttonColumn.Text = "Edit";
        }

        private void DisplayGrid()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con = ConnectionString.localconnectionstring;
                SqlCommand cmd = new SqlCommand("select class,dirFrom,dirTo,charge from amount", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private int AutoGenerateID()
        {
            int id = 0;
            SqlConnection con = new SqlConnection();
            con = ConnectionString.localconnectionstring;
            try
            {
                SqlCommand cmd = new SqlCommand(@"select * from amount", con);
                SqlDataAdapter da = new   SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return id;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            int ID =AutoGenerateID();
            SqlConnection con = new SqlConnection();
            con = ConnectionString.localconnectionstring;
            string cmd_insert = @"insert into amount(Id,class,dirFrom,dirTo,charge)
                                                  values(@id,@Class,@From,@To,@Charge)";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(cmd_insert, con);
                cmd.Parameters.Add(new SqlParameter("@id", ID));
                cmd.Parameters.Add(new SqlParameter("@Class", tbx_class.Text));
                cmd.Parameters.Add(new SqlParameter("@From", cbx_from.Text));
                cmd.Parameters.Add(new SqlParameter("@To", cbx_to.Text));
                cmd.Parameters.Add(new SqlParameter("@Charge", tbx_charge.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayGrid();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con = ConnectionString.localconnectionstring;
            string cmd_update = @"update amount
                                set charge=@Charge,
                                    dirFrom=@From,
                                    dirTo=@To,
                                    class=@Class
                                where class='" + tbx_class.Text + "' and dirFrom='" + cbx_from.Text + "' and dirTo='" + cbx_to.Text + "'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(cmd_update, con);
                cmd.Parameters.Add(new SqlParameter("@From", cbx_from.Text));
                cmd.Parameters.Add(new SqlParameter("@To", cbx_to.Text));
                cmd.Parameters.Add(new SqlParameter("@Class", tbx_class.Text));
                cmd.Parameters.Add(new SqlParameter("@Charge", tbx_charge.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayGrid();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
               dataGridView1.Columns[e.ColumnIndex].HeaderText == "Edit")
            {
                tbx_class.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                cbx_from.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                cbx_to.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                tbx_charge.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
            }         
        }

        private void Amountsetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
        }

        private void tbx_class_Enter(object sender, EventArgs e)
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

        private void tbx_class_Leave(object sender, EventArgs e)
        {
            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("osk"))
            {
                process.Kill();
            }
        }

        private void tbx_no_Leave(object sender, EventArgs e)
        {
            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("osk"))
            {
                process.Kill();
            }
        }

        private void tbx_no_Enter(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
        }

        private void tbx_charge_Enter(object sender, EventArgs e)
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

        private void tbx_charge_Leave(object sender, EventArgs e)
        {
            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("osk"))
            {
                process.Kill();
            }
        }
    }
}
