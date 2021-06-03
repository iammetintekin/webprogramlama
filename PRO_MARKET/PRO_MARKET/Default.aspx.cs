using Proje.Business;
using Proje.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRO_MARKET
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                siparisDetaydiv.Visible = false;
            }

        }

        protected void GetOrderDetails(string cargofisno)
        {
           
            PROMARKETEntities db = new PROMARKETEntities();
            //CARGOFICHENO
            INVOICES oneInvoice = new INVOICES();
            oneInvoice = db.INVOICES.Where(i => i.CARGOFICHENO == cargofisno).FirstOrDefault();
            int orderID = Convert.ToInt32(oneInvoice.ORDERID);

            ORDERS order = new ORDERS();
            Orders oneOrder = new Orders();
            order = oneOrder.getOrderDetails(orderID);
            OrderId.Text = order.ID.ToString();
            OrderDate.Text = order.DATE_.ToString();
            TotalPrice.Text = order.TOTALPRICE.ToString();

           

            var adres = db.ADDRESS.Where(a => a.ID == order.ADDRESSID).FirstOrDefault();
            Adress.Text = adres.ADDRESSTEXT;

            var kullanici = db.USERS.Where(u => u.ID == order.USERID).FirstOrDefault();
            KullaniciAdi.Text = kullanici.NAMESURNAME;
            KullaniciTelefon.Text = "No 1: " + kullanici.TELNR1 + " No 2: " + kullanici.TELNR2;
            KullaniciMail.Text = kullanici.EMAIL;

            var itemsinorder = (from x in db.ORDERDETAILS
                                join c in db.ITEMS on x.ITEMID equals c.ID
                                where x.ORDERID == orderID
                                select new
                                {
                                    UrunAdi = c.ITEMNAME,
                                    UrunAdeti = x.AMOUNT,
                                    UrunToplam = x.LINETOTAL
                                }).ToList();

            decimal toplamAlinanOdeme = 0;
            foreach (var item in itemsinorder)
            {
                toplamAlinanOdeme += Convert.ToDecimal(item.UrunToplam);
            }
            AlinanOdeme.Text = toplamAlinanOdeme.ToString();

            var faturadetay = db.INVOICES.Where(x => x.ORDERID == orderID).FirstOrDefault();
            faturaAdresi.Text = db.ADDRESS.Where(x => x.ID == faturadetay.ADDRESSID).FirstOrDefault().ADDRESSTEXT;
            KargoFisNo.Text = faturadetay.CARGOFICHENO;
            ToplamOdeme.Text = faturadetay.TOTALPRICE.ToString();

            SiparistekiUrunler.DataSource = itemsinorder;
            SiparistekiUrunler.DataBind();

            siparisDetaydiv.Visible = true;
        }

        protected void siparisKontrol_Click(object sender, EventArgs e)
        {
            GetOrderDetails(fisno.Value);
        }
    }
}