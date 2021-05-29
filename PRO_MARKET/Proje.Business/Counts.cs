using Proje.DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Business
{
    public class Counts
    {

        public string GetMonths(int month)
        {

            PROMARKETEntities db = new PROMARKETEntities();
            var result = (from order in db.ORDERS
                      join payment in db.PAYMENTS on order.ID equals payment.ORDERID
                      join invoice in db.INVOICES on order.ID equals invoice.ORDERID
                      join orderdetails in db.ORDERDETAILS on order.ID equals orderdetails.ORDERID
                      join items in db.ITEMS on orderdetails.ITEMID equals items.ID
                      where order.DATE_.Value.Month == month
                          select new
                      {
                          LineTotal = orderdetails.LINETOTAL,
                          OrderID = order.ID,
                          OrderTotalPrice = order.TOTALPRICE.ToString(),
                          OrderDate = order.DATE_.ToString(),

                      }).FirstOrDefault();

            return result.LineTotal.ToString();
    }
    }
}
