using Proje.DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Business
{
    public class Orders
    {

        PROMARKETEntities db = new PROMARKETEntities();
        public int ID { get; set; }
        public Nullable<int> USERID { get; set; }
        public Nullable<System.DateTime> DATE_ { get; set; }
        public Nullable<decimal> TOTALPRICE { get; set; }
        public Nullable<byte> STATUS_ { get; set; }
        public Nullable<int> ADDRESSID { get; set; }

        public List<ORDERS> GetAll()
        {
            PROMARKETEntities db = new PROMARKETEntities();
            var result = db.ORDERS.ToList();
            return result;
        }
        public int ListeleCount;

        public List<ORDERS> ts;

        public List<object> Listele(int pagenumber)
        {

            int totalpagecount_ = 10;

            PROMARKETEntities db = new PROMARKETEntities();

            var result = (from order in db.ORDERS
                          join user in db.USERS on order.USERID equals user.ID
                          join address in db.ADDRESS on order.ADDRESSID equals address.ID
                          join city in db.CITIES on address.CITYID equals city.ID
                          join district in db.DISTRICTS on city.ID equals district.ID
                          select new
                          {
                              OrderID = order.ID,
                              OrderTotalPrice = order.TOTALPRICE.ToString(),
                              OrderDate = order.DATE_.ToString(),
                              Username = user.NAMESURNAME.ToString(),
                              UserUsername = user.USERNAME_.ToString(),
                              Address = address.ADDRESSTEXT.ToString(),
                              CityandDistrict = city.CITY.ToString() + " / " + district.DISTRICT.ToString()

                          }).ToList();

            ListeleCount = result.ToList().Count;


            var queryresultpage = result.Skip(totalpagecount_ * (pagenumber - 1)).Take(totalpagecount_).Cast<object>();

            return queryresultpage.ToList();
        }

        public int searchedCount;
        public List<object> Search(string kadi, int pagenumber)
        {
            int totalpagecount_ = 10;

            PROMARKETEntities db = new PROMARKETEntities();


            var result = (from order in db.ORDERS
                          join user in db.USERS on order.USERID equals user.ID
                          join address in db.ADDRESS on order.ADDRESSID equals address.ID
                          join city in db.CITIES on address.CITYID equals city.ID
                          join district in db.DISTRICTS on city.ID equals district.ID
                          select new
                          {
                              OrderID = order.ID,
                              OrderTotalPrice = order.TOTALPRICE.ToString(),
                              OrderDate = order.DATE_.ToString(),
                              Username = user.NAMESURNAME.ToString(),
                              UserUsername = user.USERNAME_.ToString(),
                              UserPhone = user.TELNR1.ToString(),
                              Address = address.ADDRESSTEXT.ToString(),
                              CityandDistrict = city.CITY.ToString() + " / " + district.DISTRICT.ToString()

                          }).Where(x => x.Username.Contains(kadi) || x.UserUsername.Contains(kadi) || x.UserPhone.Contains(kadi)).ToList();
            searchedCount = result.Count;

            var queryresultpage = result.Skip(totalpagecount_ * (pagenumber - 1)).Take(totalpagecount_).Cast<object>();

            return queryresultpage.ToList();
        }

        public int getAllCount()
        {
            PROMARKETEntities db = new PROMARKETEntities();
            var result = db.ORDERS.ToList();
            return result.Count;
        }
        public ORDERS getOrderDetails(int orderId)
        {

            PROMARKETEntities db = new PROMARKETEntities();
            var result = db.ORDERS.Where(x=>x.ID == orderId).FirstOrDefault();

            return result;
        }
    }
}
