using Proje.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRO_MARKET
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Customers customers = new Customers();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CustomersCount.Text = customers.getAllCount().ToString();
            }
        }
    }
}