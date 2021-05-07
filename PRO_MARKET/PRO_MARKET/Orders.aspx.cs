using Proje.Business;
using Proje.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRO_MARKET
{
    public partial class WebForm3 : System.Web.UI.Page
    {

        Orders orders = new Orders();
        int pagenumber = 1;
        static string searchedvalue = "";
        LinkButton lnk = new LinkButton();
        protected void Page_Load(object sender, EventArgs e)
        {
            GettAllORders();
        }

        protected void GettAllORders()
        {


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

            OrderRepeater.DataSource = result;
            OrderRepeater.DataBind();
        }
    }
}