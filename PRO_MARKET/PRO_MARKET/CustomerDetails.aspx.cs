using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proje.Business;
using Proje.DataAccess;

namespace PRO_MARKET
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BringCustomerInfo();
        }

        protected void BringCustomerInfo()
        {
            int cId;
            try
            {
                cId = Convert.ToInt32(Request.QueryString["CID"].ToString());

                Customers customer = new Customers();
                USERS user1 = customer.GetCustomer(cId);
                adsoyad.Text = user1.NAMESURNAME;
                AdSoyadLabel.Text = user1.NAMESURNAME;
                kullaniciAdi.Text = user1.USERNAME_;


                string textnumbers = user1.TELNR1 + "\n" + user1.TELNR2;
                var foo = new HtmlString(textnumbers.Replace("\n", "<br/>"));
                Tel1.Text = foo.ToString();
                EmailLabel.Text = user1.EMAIL;
                Dogum.Text = Convert.ToDateTime(user1.BIRTHDATE).ToShortDateString().ToString();
                if (user1.GENDER == "K")
                {
                    Cinsiyet.ForeColor = System.Drawing.Color.Red;
                    Cinsiyet.Text = "Kadın";
                }
                else if (user1.GENDER == "E")
                {
                    Cinsiyet.ForeColor = System.Drawing.Color.Blue;
                    Cinsiyet.Text = "Erkek";
                }
                else
                {
                    Cinsiyet.Text = user1.GENDER;
                }
                UyelikTarihi.Text = Convert.ToDateTime(user1.CREATEDDATE).ToString();

                Kayitliadresler.DataSource = customer.GetCustomerAdres(cId);
                Kayitliadresler.DataBind();

                MusteriSiparisler.DataSource = customer.MusteriSiparisListele(cId);
                MusteriSiparisler.DataBind();
            }
            catch (Exception)
            {
                Response.Redirect("Customers.aspx");
            }


        }
    }
}