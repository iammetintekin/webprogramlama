using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServis;

namespace PRO_MARKET
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                siparisDetaydiv.Visible = false;
            }
            
        }


        protected void OrderDetails(string cargofisno)
        {
            try
            {
                WebService2 servis = new WebService2();
                var json = servis.GetOrderDetails(cargofisno);
                dynamic data = JObject.Parse(json);
                //label1.Text = data.itemsInOrder.Count.ToString();

                OrderId.Text = data.OrderID.ToString();
                OrderDate.Text = data.OrderDate.ToString();
                TotalPrice.Text = data.TotalPrice.ToString();
                //
                Adress.Text = data.AddressText;
                //
                KullaniciAdi.Text = data.KullaniciAdi;
                KullaniciTelefon.Text = data.KullaniciTel;
                KullaniciMail.Text = data.KullaniciMail;

                //
                decimal toplamAlinanOdeme = 0;
                foreach (var item in data.itemsInOrder)
                {
                    toplamAlinanOdeme += Convert.ToDecimal(item.UrunToplam);
                }
                AlinanOdeme.Text = data.AlinanOdeme.ToString();
                //
                faturaAdresi.Text = data.FaturaAdresi;
                KargoFisNo.Text = data.KargoFisNo;
                ToplamOdeme.Text = data.ToplamOdeme.ToString();

                SiparistekiUrunler.DataSource = data.itemsInOrder;
                SiparistekiUrunler.DataBind();

                siparisDetaydiv.Visible = true;
            }
            catch (Exception ex)
            {

                label1.Text = "Kayıt Bulunamadı";
                siparisDetaydiv.Visible = false;
            }
         
        }

        protected void siparisKontrol_Click(object sender, EventArgs e)
        {
            OrderDetails(SearchText.Text);
        }
    }
}