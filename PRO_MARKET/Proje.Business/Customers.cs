using Proje.DataAccess;
using System;
using System.Collections;
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

        public USERS GetCustomer(int userId)
        {
            PROMARKETEntities db = new PROMARKETEntities();
            USERS user = db.USERS.Where(x => x.ID == userId).FirstOrDefault();
            return user;
        }
        public List<object> GetCustomerAdres(int userId)
        {
            
            PROMARKETEntities db = new PROMARKETEntities();
            List<ADDRESS> adres = db.ADDRESS.Where(x => x.USERID == userId).ToList();
            var result = (from address in db.ADDRESS
                          join country in db.COUNTRIES on address.COUNTRYID equals country.ID
                          join city in db.CITIES on address.CITYID equals city.ID
                          join town in db.TOWNS on address.TOWNID equals town.ID
                          join district in db.DISTRICTS on address.DISTRICTID equals district.ID
                          where address.USERID == userId
                          select new
                          {
                              Adres = country.COUNTRY.ToString() + " / " + city.CITY.ToString() + " / " + town.TOWN.ToString() + " / " + district.DISTRICT.ToString() + " " + address.ADDRESSTEXT.ToString()
                          }).ToList();
            var queryresultpage = result.Cast<object>();

            return queryresultpage.ToList();
        }

        public List<object> MusteriSiparisListele(int CustomerId)
        {

            PROMARKETEntities db = new PROMARKETEntities();

            var result = (from order in db.ORDERS
                          join user in db.USERS on order.USERID equals user.ID
                          join address in db.ADDRESS on order.ADDRESSID equals address.ID
                          join city in db.CITIES on address.CITYID equals city.ID
                          join district in db.DISTRICTS on city.ID equals district.ID
                          where user.ID == CustomerId
                          select new
                          {
                              OrderID = order.ID,
                              OrderTotalPrice = order.TOTALPRICE.ToString(),
                              OrderDate = order.DATE_.ToString(),
                              Username = user.NAMESURNAME.ToString(),
                              Address = address.ADDRESSTEXT.ToString(),
                              TotalMoney = order.TOTALPRICE,
                              CityandDistrict = city.CITY.ToString() + " / " + district.DISTRICT.ToString(),
                              SiparisSayisi = db.ORDERDETAILS.Where(x=>x.ORDERID == order.ID && x.ORDERS.USERID == CustomerId).Count()

                          }).ToList();

            var queryresultpage = result.Cast<object>();

            return queryresultpage.ToList();
        }


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
