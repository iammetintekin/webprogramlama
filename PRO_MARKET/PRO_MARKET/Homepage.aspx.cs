using Proje.Business;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRO_MARKET
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Customers customers = new Customers();
        Orders orders = new Orders();
        Payments payments = new Payments();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SalesLabel.Text = payments.GetAllSales().ToString("N0", new NumberFormatInfo()
                {
                    NumberGroupSizes = new[] { 3 },
                    NumberGroupSeparator = "."
                }); 
                AllEarnings.Text = payments.GetAllMoney().ToString("N0", new NumberFormatInfo()
                {
                    NumberGroupSizes = new[] { 3 },
                    NumberGroupSeparator = "."
                });
                CustomersCount.Text = customers.getAllCount().ToString("N0", new NumberFormatInfo()
                {
                    NumberGroupSizes = new[] { 3 },
                    NumberGroupSeparator = "."
                }); 
                OrdersCount.Text = orders.getAllCount().ToString("N0", new NumberFormatInfo()
                {
                    NumberGroupSizes = new[] { 3 },
                    NumberGroupSeparator = "."
                }); 
            }
        }

        [ScriptMethod]
        [WebMethod(EnableSession = true)]
        public static string OrnekPost(string parametre)
        {
            return parametre + " değeriyle post işlemi gerçekleştirildi.";
        }



        //[WebMethod(EnableSession = true)]
        //[ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        //public static string OrnekPost(string parametre)
        //{
        //    return parametre + " değeriyle post işlemi gerçekleştirildi.";
        //}

        [ScriptMethod]
        [WebMethod(EnableSession = true)]
        public static string BringDatas(string month)
        {
            Counts counts_ = new Counts();
          //  return month + "month";
            return counts_.GetMonths(Convert.ToInt32(month));
        }
    }
}