using Proje.Business;
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
        static SqlDataReader source;
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
            if(textBox.Text == "")
            {
                getAllCustomers();
            }
            else
            {
                Customers customers = new Customers();
                source = customers.GetByUsername(textBox.Text);
                CustomerRepeater.DataSource = source;
                CustomerRepeater.DataBind();
            }
                
        }

        protected void getAllCustomers()
        {
            Customers customers = new Customers();
            source = customers.GetAll();
            CustomerRepeater.DataSource = source;
            CustomerRepeater.DataBind();

             customersCount.Text = " Showing total " + customers.GetTableCounts().ToString() + " rows";
        }
    }
}