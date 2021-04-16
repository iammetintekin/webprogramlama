using Proje.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRO_MARKET
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Customers customers = new Customers();
            //CustomerRepeater.DataSource = customers.GetCustomers("");
            //CustomerRepeater.DataBind();

            //CustomerRepeater.DataSource = customers.GetCustomersById(1);
            //CustomerRepeater.DataBind();
        }

    }
}