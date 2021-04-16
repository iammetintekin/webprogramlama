using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.DataAccess
{
    public class DatabaseConnection
    {
        public SqlConnection Connect()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ToString());
            connection.Open();
            return connection;
        }
        
    }
}
