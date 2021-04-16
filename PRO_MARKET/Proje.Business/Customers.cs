using Proje.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Proje.Business
{
    public class Customers
    {
        public SqlDataReader GetCustomers()
        {
            DatabaseConnection connection = new DatabaseConnection();
            SqlConnection conn =  connection.Connect();
            SqlCommand command;
            
            SqlDataReader reader;
            command = new SqlCommand("select * from USERS", conn);
            reader = command.ExecuteReader();

            return reader;

        }
        public SqlDataReader GetCustomersById(int Id)
        {
            
            List<string> parameters = new List<string>();
            string commandtext = "select * from USERS WHERE ID = @ID";
            DatabaseConnection connection = new DatabaseConnection();
            SqlConnection conn = connection.Connect();
            SqlCommand command;
            SqlDataReader reader;
            command = new SqlCommand(commandtext, conn);
            command.Parameters.AddWithValue("@ID", Id.ToString());
            reader = command.ExecuteReader();
            return reader;

        }
    }
}
