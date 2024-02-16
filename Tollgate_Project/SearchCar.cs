using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using MySql.Data.MySqlClient;
using onvif.services;
using Ozeki.VoIP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tollgate_Project
{
    public partial class SearchCar : Form
    {
        private List<DataGridViewColumn> originalColumnsOrder;
        Bitmap bmp;
        string localconnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Tollgate_database.mdf;Integrated Security=True";

        public SearchCar()
        {
            InitializeComponent();
            DisplayGrid();
            AddBtnToGrid();
            SetDatePickerCustomFormat();
        }

        private void SearchCarImage(string image)
        {
            try
            {
                // string defaultfilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "TollCaptureLic_" + image+".jpg");
                string defaultfilePath = image;
                Image loadedImage = Image.FromFile(defaultfilePath);
                pictureBox1.Image = loadedImage;
            }
            catch(Exception ex) {
                MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void SetDatePickerCustomFormat()
        {
           /* dateTimePicker_startdate.CustomFormat = "MMM d yyyy h:mmtt";
            dateTimePicker_startdate.Format = DateTimePickerFormat.Custom;
            dateTimePicker_enddate.CustomFormat = "MMM d yyyy h:mmtt";
            dateTimePicker_enddate.Format = DateTimePickerFormat.Custom;*/
        }

        private void SelectPeriod()
        {

            MySqlConnection con = new MySqlConnection();
            con = ConnectionString.connectionstring;
            string cmd_selectperiod = @"select * from Record where timedate between @Startdate and @Enddate";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(cmd_selectperiod, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                //cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Startdate", dateTimePicker_startdate.Text));
                //cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Enddate", dateTimePicker_enddate.Text));
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    List<DataGridViewColumn> columns = new List<DataGridViewColumn>();
                    foreach (DataGridViewColumn column in carlist_dataGridView1.Columns)
                    {
                        columns.Add(column);
                    }
                    carlist_dataGridView1.DataSource = dt;

                    foreach (DataGridViewColumn column in columns)
                    {
                        if (!carlist_dataGridView1.Columns.Contains(column.Name))
                        {
                            carlist_dataGridView1.Columns.Add(column);
                        }
                        else
                        {
                            carlist_dataGridView1.Columns[column.Name].DisplayIndex = column.DisplayIndex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SelectDate()
        {
            MySqlConnection con = new MySqlConnection();
            con = ConnectionString.connectionstring;
            string cmd_selectperiod = @"select * from Record where timedate=@Startdate";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(cmd_selectperiod, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                //cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Startdate", dateTimePicker_startdate.Text));
              //  cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Enddate", dateTimePicker_enddate.Text));
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    List<DataGridViewColumn> columns = new List<DataGridViewColumn>();
                    foreach (DataGridViewColumn column in carlist_dataGridView1.Columns)
                    {
                        columns.Add(column);
                    }
                    carlist_dataGridView1.DataSource = dt;

                    foreach (DataGridViewColumn column in columns)
                    {
                        if (!carlist_dataGridView1.Columns.Contains(column.Name))
                        {
                            carlist_dataGridView1.Columns.Add(column);
                        }
                        else
                        {
                            carlist_dataGridView1.Columns[column.Name].DisplayIndex = column.DisplayIndex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void SearchByLicense()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(localconnection))
                {
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("select license,class,gateid,dirFrom,dirTo,charge,timedate,laneid from record where license=@Licenses", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.Parameters.Add(new SqlParameter("@Licenses", tbx_searchbylicense.Text));

                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        List<DataGridViewColumn> columns = new List<DataGridViewColumn>();
                        foreach (DataGridViewColumn column in carlist_dataGridView1.Columns)
                        {
                            columns.Add(column);
                        }
                        carlist_dataGridView1.DataSource = dt;

                        foreach (DataGridViewColumn column in columns)
                        {
                            if (!carlist_dataGridView1.Columns.Contains(column.Name))
                            {
                                carlist_dataGridView1.Columns.Add(column);
                            }
                            else
                            {
                                carlist_dataGridView1.Columns[column.Name].DisplayIndex = column.DisplayIndex;
                            }
                        }
                    }
                }
              
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (tbx_searchbylicense.Text != "")
            {
                SearchByLicense();
            }
            else
            {
                MessageBox.Show("Please enter a license to search");
            }
        }

        private void AddBtnToGrid()
        {
            DataGridViewButtonColumn addbuttonColumn = new DataGridViewButtonColumn();
            addbuttonColumn.HeaderText = "Detail";
            addbuttonColumn.UseColumnTextForButtonValue = true;
            carlist_dataGridView1.Columns.Insert(8, addbuttonColumn);
            addbuttonColumn.Text = "Detail";
        }

        private void RefreshGrid()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(localconnection))
                {
                    SqlCommand cmd = new SqlCommand("select license,class,gateid,dirFrom,dirTo,charge,timedate,laneid from Record", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        if (originalColumnsOrder == null)
                        {
                            // Store the original column order only if it hasn't been stored yet
                            originalColumnsOrder = new List<DataGridViewColumn>();
                            foreach (DataGridViewColumn column in carlist_dataGridView1.Columns)
                            {
                                originalColumnsOrder.Add(column);
                            }
                        }

                        // Clear existing columns
                        carlist_dataGridView1.Columns.Clear();

                        // Add columns from original order
                        foreach (DataGridViewColumn column in originalColumnsOrder)
                        {
                            carlist_dataGridView1.Columns.Add(column.Clone() as DataGridViewColumn);
                        }

                        carlist_dataGridView1.DataSource = dt;
                    }
                    AddBtnToGrid();

                    carlist_dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DisplayGrid()
        {
            try
            {            
                using (SqlConnection con = new SqlConnection(localconnection))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT license, class, gateid, dirFrom, dirTo, charge, timedate, laneid FROM record", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        if (originalColumnsOrder == null)
                        {
                            originalColumnsOrder = new List<DataGridViewColumn>();
                            foreach (DataGridViewColumn column in carlist_dataGridView1.Columns)
                            {
                                originalColumnsOrder.Add(column);
                            }
                        }

                        carlist_dataGridView1.Columns.Clear();

                        foreach (DataGridViewColumn column in originalColumnsOrder)
                        {
                            carlist_dataGridView1.Columns.Add(column.Clone() as DataGridViewColumn);
                        }

                        carlist_dataGridView1.DataSource = dt;
                    }

                    carlist_dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {              
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void carlist_dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && carlist_dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    carlist_dataGridView1.Columns[e.ColumnIndex].HeaderText == "Detail")
            {
                DataGridViewRow row = carlist_dataGridView1.Rows[e.RowIndex];
                string license = row.Cells[1].Value.ToString();
                string classno = row.Cells[2].Value.ToString();
                string charge = row.Cells[6].Value.ToString();
                string datetime = row.Cells[7].Value.ToString();
                string keyName = "license/" + license + "_" + datetime;
                string bucketName = "tollgate-upload";
                GetImageFromS3(bucketName,keyName);
            }
        }

        private void DisplayDetail(string License,string Classno, string charge,string datetime)
        {
            lbl_license.Text = License;
            lbl_class.Text = Classno;
            lbl_charge.Text = charge;
            lbl_date.Text = datetime;
        }

        private void SearchCar_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            if (carlist_dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = "Record.csv";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = carlist_dataGridView1.Columns.Count;
                            string columnNames = "";
                            string[] outputCsv = new string[carlist_dataGridView1.Rows.Count + 1];
                            for (int i = 1; i < columnCount; i++)
                            {
                                columnNames += carlist_dataGridView1.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCsv[0] += columnNames;

                            for (int i = 1; (i - 1) < carlist_dataGridView1.Rows.Count; i++)
                            {
                                for (int j = 1; j < columnCount; j++)
                                {
                                    outputCsv[i] += (carlist_dataGridView1.Rows[i - 1].Cells[j].Value ?? "").ToString() + ",";
                                }
                                // Add a newline character at the end of each line
                                outputCsv[i] = outputCsv[i].TrimEnd(',') + Environment.NewLine;
                            }

                            File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                            MessageBox.Show("Data Exported Successfully !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }

        private void dateTimePicker_startdate_ValueChanged(object sender, EventArgs e)
        {

        }

        

        private void btn_sync_Click(object sender, EventArgs e)
        {
            MSSQLTOMYSQL mSSQLTOMYSQL = new MSSQLTOMYSQL();
            mSSQLTOMYSQL.SyncMySqlData();
           // AWSsync sync= new AWSsync();
           // sync.SyncMySqlData();
            
        }

        private void GetImageFromS3(string bucketName, string keyName)
        {
           // string regionSystemName = "ap-southeast-1"; // System name for Asia Pacific (Singapore) region
           // RegionEndpoint region = RegionEndpoint.GetBySystemName(regionSystemName);
            
            try
            {
                RegionEndpoint region = RegionEndpoint.GetBySystemName("ap-southeast-1");
                AmazonS3Client s3Client = new AmazonS3Client("AKIA2URURO2QMSBXZFQV", "d+0JZxKfdnVPBMQ4oloBLnkTMHX7KeYr/ct5WtVc", region);
                GetObjectRequest request = new GetObjectRequest
                {
                    BucketName = bucketName,
                    Key = keyName
                };
                using (GetObjectResponse response = s3Client.GetObject(request))
                using (Stream responseStream = response.ResponseStream)
                {
                    // Load the image from S3 response stream
                    Image image = Image.FromStream(responseStream);

                    // Display the image in PictureBox
                    pictureBox1.Image = image;
                }
            }
            catch (AmazonS3Exception ex)
            {
                MessageBox.Show("Error getting object from S3: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
