using MySql.Data.MySqlClient;
using onvif.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Tollgate_Project
{
    public partial class Record : Form
    {
        public Record()
        {
          
            InitializeComponent();
            DisplayGrid();
        }

        private bool CheckInternetConnectivity()
        {
            try
            {
                using (var ping = new Ping())
                {
                    var result = ping.Send("www.google.com");
                    return (result.Status == IPStatus.Success);
                }
            }
            catch
            {
                return false;

            }

        }

        private void DisplayGrid()
        {
            
            try
            {

             MySqlConnection con = new MySqlConnection();
            /*SqlConnection con = new SqlConnection(
                 new SqlConnectionStringBuilder()
                 {
                     DataSource = "MSI\\LOCALDB#F72428E0",

                     InitialCatalog = "tollGateCloneDB",
                     UserID = "admin",
                     Password = "sawwinthant"
                 }.ConnectionString
                 );*/
            //con = ConnectionString.connectionstring;
            con = ConnectionString.connectionstring;
            MySqlCommand cmd = new MySqlCommand("select license,class,gateid,[from],[to],charge,timedate,laneid from Record", con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void Record_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            DisplayGrid();
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection();
            con = ConnectionString.awsconnectionstring;
            MySqlCommand cmd = new MySqlCommand(@"select * from Record", con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel (.xlsx)|  *.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Excel.Application XcelApp = new Excel.Application();
                        Excel._Workbook workbook = XcelApp.Workbooks.Add(Type.Missing);
                        Excel._Worksheet worksheet = null;

                        worksheet = workbook.Sheets["Sheet1"];
                        worksheet = workbook.ActiveSheet;
                        worksheet.Name = "Output";
                        worksheet.Application.ActiveWindow.SplitRow = 1;
                        worksheet.Application.ActiveWindow.FreezePanes = true;

                        for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                        {
                            worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                            worksheet.Cells[1, i].Font.NAME = "Calibri";
                            worksheet.Cells[1, i].Font.Bold = true;
                            worksheet.Cells[1, i].Interior.Color = System.Drawing.Color.Wheat;
                            worksheet.Cells[1, i].Font.Size = 12;
                        }

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            for (int j = 0; j < dataGridView1.Columns.Count; j++)
                            {
                                DataGridViewCell cell = dataGridView1[j, i];
                                worksheet.Cells[i + 2, j + 1] = cell.Value;
                            }
                        }

                        worksheet.Columns.AutoFit();
                        workbook.SaveAs(sfd.FileName);
                        XcelApp.Quit();

                        releaseObject(worksheet);
                        releaseObject(workbook);
                        releaseObject(XcelApp);

                        MessageBox.Show("Data Exported Successfully !!!", "Info");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error :" + ex.Message);
                    }
                }
            }
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

		private void btn_search_Click(object sender, EventArgs e)
		{

			try
			{
				MySqlConnection con = new MySqlConnection();
                con = ConnectionString.connectionstring;
				DataTable dt = new DataTable();
				MySqlCommand cmd = new MySqlCommand("Select * from Record where license=@Licenses", con);
				MySqlDataAdapter da = new MySqlDataAdapter(cmd);
				cmd.Parameters.Add(new SqlParameter("@Licenses", tbx_search.Text));
				
				da.Fill(dt);
				if (dt.Rows.Count > 0)
				{
					dataGridView1.DataSource = dt;
				}
			}

			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

       

        private void tbx_search_Enter(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
        }

        private void tbx_search_Leave(object sender, EventArgs e)
        {
            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("osk"))
            {
                process.Kill();
            }
        }

        private void tbx_id_Leave(object sender, EventArgs e)
        {
            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("osk"))
            {
                process.Kill();
            }
        }

        private void tbx_id_Enter(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
        }
    }
}
