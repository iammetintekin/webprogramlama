using Proje.DataAccess;
using System;
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
        
        public void Listele(int pagenumber)
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


            var queryresultpage = result.Skip(totalpagecount_ * (pagenumber - 1)).Take(totalpagecount_);

        }

        public int searchedCount;
        public List<ORDERS> Search(string kadi, int pagenumber)
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

                         }).Where(x=>x.Username.Contains(kadi) || x.UserUsername.Contains(kadi)).ToList();
            searchedCount = result.Count;

            var queryresultpage = result.Skip(totalpagecount_ * (pagenumber - 1)).Take(totalpagecount_);

            return (List<ORDERS>)queryresultpage;
        }

        public int getAllCount()
        {
            PROMARKETEntities db = new PROMARKETEntities();
            var result = db.ORDERS.ToList();
            return result.Count;
        }
        public int getSearchedCount()
        {

            PROMARKETEntities db = new PROMARKETEntities();
            var result = db.ORDERS.ToList();
            return result.Count;
        }
    }
}
