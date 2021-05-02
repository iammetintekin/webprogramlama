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
        public int ID { get; set; }
        public string USERNAME_ { get; set; }
        public string PASSWORD_ { get; set; }
        public string NAMESURNAME { get; set; }
        public string EMAIL { get; set; }
        public string GENDER { get; set; }
        public Nullable<System.DateTime> BIRTHDATE { get; set; }
        public Nullable<System.DateTime> CREATEDDATE { get; set; }
        public string TELNR1 { get; set; }
        public string TELNR2 { get; set; }

        public List<USERS> Listele()
        {
            PROMARKETEntities db = new PROMARKETEntities();
            var result = db.USERS.ToList();
            return result;
        }

    }
}
