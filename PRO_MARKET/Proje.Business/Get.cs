using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Business
{
    public interface IGet
    {
        SqlDataReader GetById(int Id);
        SqlDataReader GetAll();
        SqlDataReader GetByUsername(string username);

        int GetTableCounts();

    }
}
