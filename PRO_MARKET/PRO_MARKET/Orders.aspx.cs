using Proje.Business;
using Proje.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
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
            if (!IsPostBack)
            { getAllOrders(pagenumber); }

        }

        protected void SearchChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            searchedvalue = textBox.Text;
            bool isnull = String.IsNullOrEmpty(searchedvalue);
            if (isnull == true)
            {
                getAllOrders(pagenumber);
            }
            else
            {
                getAllOrderByPhone(textBox.Text, pagenumber);
                searchedvalue = textBox.Text;
            }

        }

        protected void getAllOrders(int page)
        {
            Orders orders = new Orders();
            var source = orders.Listele(pagenumber);
            OrderRepeater.DataSource = source;
            OrderRepeater.DataBind();
            ordersCount.Text = " Showing total " + page * source.Count() + " of " + orders.ListeleCount + " rows";
            CreatePagingButtons(page, orders.ListeleCount);
        }

        protected void getAllOrderByPhone(string phone, int page)
        {
            Orders orders = new Orders();
            var source = orders.Search(phone, pagenumber);
            OrderRepeater.DataSource = source;
            OrderRepeater.DataBind();
            ordersCount.Text = " Showing total " + page * source.Count() + " of " + orders.searchedCount + " rows";
            CreatePagingButtons(page, orders.searchedCount);
        }

        protected void CreatePagingButtons(int sendedPageNumber, int count)
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

            Orders orders = new Orders();
            LinkButton pagevalue = (LinkButton)sender;

            lnk = pagevalue;

            lnk.Text = pagevalue.Text;

            if (lnk.Text == "Başa Dön")
            {
                pagenumber = 1;
            }
            else if (lnk.Text == "Son")
            {
                if (orders.getAllCount() % 10 > 0)
                {
                    pagenumber = (orders.getAllCount() / 10) + 1;
                    getAllOrders(pagenumber);
                }
                else
                {
                    pagenumber = orders.getAllCount() / 10;
                    getAllOrders(pagenumber);
                }

            }
            else
            {
                pagenumber = Convert.ToInt32(pagevalue.Text);
                getAllOrders(pagenumber);
            }




            if (searchedvalue != "")
            {
                getAllOrderByPhone(searchedvalue, pagenumber);
            }
            else
            {
                getAllOrders(pagenumber);
            }
        }


    }
}