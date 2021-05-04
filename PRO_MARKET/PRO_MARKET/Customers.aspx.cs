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
        LinkButton lnk = new LinkButton();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getAllCustomers(pagenumber);
            }



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
            customersCount.Text = " Showing total " + page * source.Count() + " rows";
            CreatePagingButtons(page);
        }

        protected void CreatePagingButtons(int sendedPageNumber)
        {
            Customers customers = new Customers();//5000/10=500
            int s1 = customers.getAllCount();
            int pagecount_ = s1 / 10;
            List<string> pages_ = new List<string>();
            var pages = pages_;

            for (int i = 1; i < pagecount_ + 1; i++)
            {
                pages.Add(i.ToString());
            }

            if (sendedPageNumber < 5)
            {
                pagesrepeater.DataSource = pages.Take(10);
                pagesrepeater.DataBind();
            }
            else
            {
                pagesrepeater.DataSource = pages.Skip(sendedPageNumber - 4).Take(10);
                pagesrepeater.DataBind();
            }


        }

        protected string checkCurrentPage(string page)
        {
            if (lnk.Text == page)
            {
                return "page-link bg-info text-white";
            }
            return "page-link bg-light";
        }

        protected void sendCurrentPage(object sender, EventArgs e)
        {

            LinkButton pagevalue = (LinkButton)sender;
            lnk = pagevalue;
            lnk.Text = pagevalue.Text;
            pagenumber = Convert.ToInt32(pagevalue.Text);
            getAllCustomers(Convert.ToInt32(pagevalue.Text));

        }
    }
}