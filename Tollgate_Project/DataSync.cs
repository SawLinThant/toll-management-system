using Amazon.RDSDataService.Model;
using Amazon.RDSDataService;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace Tollgate_Project
{
    internal class DataSync
    {
        private const string SourceConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Tollgate_database.mdf;Integrated Security=True";
        private const string TargetConnectionString = "Data Source=database-1.crenzxc09zzc.ap-southeast-1.rds.amazonaws.com,1433;Initial Catalog=TollgateDatabase;Persist Security Info=True;User ID=admin;Password=Saw973854868#";

        public void SyncData()
        {
            try
            {
                // Retrieve data from the source database
                System.Data.DataTable sourceData = RetrieveDataFromSource();
                //Remove primary key column
                RemovePrimaryKeyColumn(sourceData);
                // Insert data into the target database
                InsertDataIntoTarget(sourceData);
                
                System.Data.DataTable sourceBarcode = RetrieveBarcodeFromSource();
                InsertBarcodeIntoTarget(sourceBarcode);

                DeleteDataFromSource();
                DeleteBarcodeFromSource();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Sync Successful");

        }

        private System.Data.DataTable RetrieveDataFromSource()
        {
           
                using (SqlConnection connection = new SqlConnection(SourceConnectionString))
                {
                    connection.Open();

                    // Execute a SQL query to retrieve data
                    string query = "select * from BackupRecord";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    // Fill the DataTable with the retrieved data
                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    adapter.Fill(dataTable);

                    return dataTable;
                }              
        }

        private void RemovePrimaryKeyColumn(System.Data.DataTable data)
        {
            // Remove the primary key column from the DataTable
            data.Columns.Remove("Id"); // Replace "id" with the actual name of your primary key column
        }

        private void InsertDataIntoTarget(System.Data.DataTable data)
        {
            using (SqlConnection connection = new SqlConnection(TargetConnectionString))
            {
                connection.Open();

                // Create a SQL bulk copy object to efficiently insert data into the target database
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.DestinationTableName = "Record";
                    // Map the columns from the source DataTable to the target table columns
                    foreach (DataColumn column in data.Columns)
                    {
                        bulkCopy.ColumnMappings.Add(column.ColumnName, column.ColumnName);
                    }

                    // Perform the bulk copy operation
                    bulkCopy.WriteToServer(data);
                   
                }
            }
            
        }

        private System.Data.DataTable RetrieveBarcodeFromSource()
        {

            using (SqlConnection connection = new SqlConnection(SourceConnectionString))
            {
                connection.Open();

                // Execute a SQL query to retrieve data
                string query = "SELECT barcode FROM BackupBarcode";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                // Fill the DataTable with the retrieved data
                System.Data.DataTable dataTable = new System.Data.DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        private void InsertBarcodeIntoTarget(System.Data.DataTable data)
        {
            using (SqlConnection connection = new SqlConnection(TargetConnectionString))
            {
                connection.Open();

                // Create a SQL bulk copy object to efficiently insert data into the target database
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.DestinationTableName = "Barcode";
                    // Map the columns from the source DataTable to the target table columns
                    foreach (DataColumn column in data.Columns)
                    {
                        bulkCopy.ColumnMappings.Add(column.ColumnName, column.ColumnName);
                    }

                    // Perform the bulk copy operation
                    bulkCopy.WriteToServer(data);
                }
            }
        }

        private void DeleteDataFromSource()
        {
            using (SqlConnection connection = new SqlConnection(SourceConnectionString))
            {
                connection.Open();

                // Execute a SQL DELETE statement to delete data from the source table
                string deleteQuery = "Delete from BackupRecord";
                SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                deleteCommand.ExecuteNonQuery();
            }
        }

        private void DeleteBarcodeFromSource()
        {
            using (SqlConnection connection = new SqlConnection(SourceConnectionString))
            {
                connection.Open();

                // Execute a SQL DELETE statement to delete data from the source table
                string deleteQuery = "Delete from BackupBarcode";
                SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                deleteCommand.ExecuteNonQuery();
            }
        }     

       
    }

    
}
