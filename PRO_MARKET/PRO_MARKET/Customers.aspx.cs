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
        int pagenumber = 1;
        static string searchedvalue = "";
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
            searchedvalue = textBox.Text;
            bool isnull = String.IsNullOrEmpty(searchedvalue);
            if (isnull==true)
            {
                getAllCustomers(pagenumber);
            }
            else
            {
                getAllCustomersByUsername(textBox.Text, pagenumber);
                searchedvalue = textBox.Text;
            }

        }

        protected void getAllCustomers(int page)
        {
            Customers customers = new Customers();
            var source = customers.Listele(pagenumber);
            CustomerRepeater.DataSource = source;
            CustomerRepeater.DataBind();
            customersCount.Text = " Showing total " + page * source.Count() + " of "+customers.ListeleCount + " rows";
            CreatePagingButtons(page, customers.ListeleCount);
        }

        protected void getAllCustomersByUsername(string username,int page)
        {
            Customers customers = new Customers();
            var source = customers.Search(username, pagenumber);
            CustomerRepeater.DataSource = source;
            CustomerRepeater.DataBind();
            customersCount.Text = " Showing total " + page * source.Count() + " of " + customers.searchedCount + " rows";
            CreatePagingButtons(page, customers.searchedCount);
        }

        protected void CreatePagingButtons(int sendedPageNumber,int count)
        {

            int pagecount_ = count / 10;
            if (pagecount_ % 10 > 0)
            {
                pagecount_ += 1;
            }
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

            Customers customers = new Customers();
            LinkButton pagevalue = (LinkButton)sender;

            lnk = pagevalue;
            
            lnk.Text = pagevalue.Text;

            if (lnk.Text == "Başa Dön")
            {
                pagenumber = 1;
            }
            else if (lnk.Text == "Son")
            {
                if (customers.getAllCount() % 10 > 0)
                {
                    pagenumber = (customers.getAllCount() / 10) + 1 ;
                    getAllCustomers(pagenumber);
                }
                else
                {
                    pagenumber = customers.getAllCount() / 10;
                    getAllCustomers(pagenumber);
                }

            }
            else
            {
                pagenumber = Convert.ToInt32(pagevalue.Text);
                getAllCustomers(pagenumber);
            }
            
            


            if (searchedvalue != "")
            {
                getAllCustomersByUsername(searchedvalue, pagenumber);
            }
            else
            {
                getAllCustomers(pagenumber);
            }
            

        }
    }
}