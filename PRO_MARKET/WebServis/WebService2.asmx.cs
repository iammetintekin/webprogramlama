using System;
using Proje.Business;
using Proje.DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Collections;

namespace WebServis
{
    /// <summary>
    /// Yazılan fiş numarasına göre detayları getirme
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService2 : System.Web.Services.WebService
    {
        [WebMethod]
        public string GetOrderDetails(string cargofisno)
        {

            //CRGF0000005451
            Details details = new Details();
            PROMARKETEntities db = new PROMARKETEntities();
            //CARGOFICHENO
            INVOICES oneInvoice = new INVOICES();
            oneInvoice = db.INVOICES.Where(i => i.CARGOFICHENO == cargofisno).FirstOrDefault();
            int orderID = Convert.ToInt32(oneInvoice.ORDERID);

            ORDERS order = new ORDERS();
            Orders oneOrder = new Orders();
            order = oneOrder.getOrderDetails(orderID);
            details.OrderID = order.ID.ToString();
            details.OrderDate = (DateTime)order.DATE_;
            details.TotalPrice = (decimal)order.TOTALPRICE;
            var adres = db.ADDRESS.Where(a => a.ID == order.ADDRESSID).FirstOrDefault();
            details.AddressText = adres.ADDRESSTEXT;

            var kullanici = db.USERS.Where(u => u.ID == order.USERID).FirstOrDefault();
            details.KullaniciAdi = kullanici.NAMESURNAME;
            details.KullaniciTel = "No 1: " + kullanici.TELNR1 + " No 2: " + kullanici.TELNR2;
            details.KullaniciMail = kullanici.EMAIL;

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

            details.AlinanOdeme = toplamAlinanOdeme;

            var faturadetay = db.INVOICES.Where(x => x.ORDERID == orderID).FirstOrDefault();
            details.FaturaAdresi = db.ADDRESS.Where(x => x.ID == faturadetay.ADDRESSID).FirstOrDefault().ADDRESSTEXT;
            details.KargoFisNo = faturadetay.CARGOFICHENO;
            details.ToplamOdeme = faturadetay.TOTALPRICE.ToString();

            details.itemsInOrder = itemsinorder.ToList<object>();
            var json = new JavaScriptSerializer().Serialize(details);
            return json;
        }
    }

    public class Details
    {
        public string OrderID;
        public DateTime OrderDate;
        public decimal TotalPrice;
        public string AddressText;
        public string KullaniciAdi;
        public string KullaniciTel;
        public string KullaniciMail;
        public decimal AlinanOdeme;
        public string FaturaAdresi;
        public string KargoFisNo;
        public string ToplamOdeme;
        public List<object> itemsInOrder;
    }
}
