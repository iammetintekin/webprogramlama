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
        static int pagenumber = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            
                getAllCustomers(pagenumber);
                CreatePagingButtons();
            
        }

        protected void SearchChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "")
            {
                getAllCustomers(pagenumber);
            }
            else
            {
                Customers customers = new Customers();
                var source = customers.Search(textBox.Text, pagenumber);
                CustomerRepeater.DataSource = source;
                CustomerRepeater.DataBind();
                customersCount.Text = " Showing total " + pagenumber * 10 + " of " + customers.getAllCount().ToString() + " rows";
            }

        }

        protected void getAllCustomers(int page)
        {
            Customers customers = new Customers();
            var source = customers.Listele(page);
            CustomerRepeater.DataSource = source;
            CustomerRepeater.DataBind();
            customersCount.Text = " Showing total " + source.Count().ToString() + " rows";
        }

        protected void CreatePagingButtons()
        {
            Customers customers = new Customers();//5000/10=500
            int s1 = customers.getAllCount();
            int pagecount_ = s1 / 10;
            List<string> pages_ = new List<string>();
            var pages = pages_;

            for (int i = 1; i < pagecount_+1; i++)
            {
                pages.Add(i.ToString());
            }


            pagesrepeater.DataSource = pages.Skip(1 * (pagenumber - 1)).Take(8);
            pagesrepeater.DataBind();

        }

        protected void sendCurrentPage(object sender, EventArgs e)
        {

            LinkButton pagevalue = (LinkButton)sender;
            pagenumber = Convert.ToInt32(pagevalue.Text);
            pagevalue.CssClass = "page-link bg-info";
            getAllCustomers(Convert.ToInt32(pagevalue.Text));
        }
    }
}