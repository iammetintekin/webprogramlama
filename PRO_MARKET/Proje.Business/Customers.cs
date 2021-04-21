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
    public class Customers : IGet
    {
      
        public SqlDataReader GetAll()
        {
            DatabaseConnection connection = new DatabaseConnection();
            SqlConnection conn = connection.Connect();
            SqlCommand command;

            SqlDataReader reader;
            command = new SqlCommand("select * from USERS WHERE ID<25", conn);
            reader = command.ExecuteReader();

            return reader;
        }

        public SqlDataReader GetById(int Id)
        {
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

        public SqlDataReader GetByUsername(string username)
        {
            string commandtext = "SELECT * FROM USERS WHERE CHARINDEX(@USERNAME_, USERNAME_)>0";

            //string commandtext = "select * from USERS WHERE (USERNAME_ LIKE %'@USERNAME_'%";
            DatabaseConnection connection = new DatabaseConnection();
            SqlConnection conn = connection.Connect();
            SqlCommand command;
            SqlDataReader reader;
            command = new SqlCommand(commandtext, conn);
            command.Parameters.AddWithValue("@USERNAME_", username);
            reader = command.ExecuteReader();
            return reader;
        }
    }
}
