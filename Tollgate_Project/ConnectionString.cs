using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Ozeki;

namespace Tollgate_Project
{
   
    public class ConnectionString
    {
        public static SqlConnection localconnectionstring
        {
            get
            {
                return new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Tollgate_database.mdf;Integrated Security=True");
            }
        }

        public static MySqlConnection connectionstring
        {
            get
            {
                return new MySqlConnection($"server={Properties.Settings.Default.dbservername};uid={Properties.Settings.Default.dbuserid};pwd={Properties.Settings.Default.dbpassword};database={Properties.Settings.Default.dbname}");
            }
        }

        public static MySqlConnection awsconnectionstring
        {
            get
            {
                return new MySqlConnection($"server={Properties.Settings.Default.cloudservername};uid={Properties.Settings.Default.clouddbuserid};pwd={Properties.Settings.Default.clouddbpassword};database={Properties.Settings.Default.clouddbname}");
            }
        }

       
    }
}
