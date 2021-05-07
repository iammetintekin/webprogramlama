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


        public List<USERS> GetAll()
        {
            PROMARKETEntities db = new PROMARKETEntities();
            var result = db.USERS.ToList();
            return result;
        }
        public int ListeleCount;
        public List<USERS> Listele(int pagenumber)
        {
            int totalpagecount_ = 10;
            PROMARKETEntities db = new PROMARKETEntities();
            var result = db.USERS.ToList();
            ListeleCount = result.Count;
            var queryresultpage = result.Skip(totalpagecount_ * (pagenumber - 1)).Take(totalpagecount_).ToList();
            return queryresultpage;
        }

        public int searchedCount;
        public List<USERS> Search(string kadi, int pagenumber)
        {
            int totalpagecount_ = 10;
            PROMARKETEntities db = new PROMARKETEntities();
            var result = db.USERS.Where(x => x.USERNAME_.Contains(kadi) || x.NAMESURNAME.Contains(kadi)).OrderBy(x => x.ID).ToList();
            searchedCount = result.Count;
            var queryresultpage = result.Skip(totalpagecount_ * (pagenumber - 1)).Take(totalpagecount_).ToList();
            return queryresultpage;
        }

        public int getAllCount()
        {

            PROMARKETEntities db = new PROMARKETEntities();
            var result = db.USERS.ToList();
            return result.Count;
        }
        public int getSearchedCount()
        {

            PROMARKETEntities db = new PROMARKETEntities();
            var result = db.USERS.ToList();
            return result.Count;
        }
    }
}
