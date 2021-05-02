using Proje.Business;
using Proje.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRO_MARKET
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        PROMARKETEntities db = new PROMARKETEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                getAllCustomers();
            }

        }

        protected void SearchChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "")
            {
                getAllCustomers();
            }
            else
            {
            }

        }

        protected void getAllCustomers()
        {
            Customers customers = new Customers();
            var source = customers.Listele();
            CustomerRepeater.DataSource = source;
            CustomerRepeater.DataBind();

            customersCount.Text = " Showing total " + source.Count().ToString() + " rows";
        }
    }
}