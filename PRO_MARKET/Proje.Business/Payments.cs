using Proje.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Business
{
    public class Payments
    {

        PROMARKETEntities db = new PROMARKETEntities();
        public int ID { get; set; }
        public Nullable<int> ORDERID { get; set; }
        public Nullable<byte> PAYMENTTYPE { get; set; }
        public Nullable<System.DateTime> DATE_ { get; set; }
        public Nullable<bool> ISOK { get; set; }
        public string APPROVECODE { get; set; }
        public Nullable<decimal> PAYMENTTOTAL { get; set; }

    

        public int GetAllSales()
        {
        //    PROMARKETEntities db = new PROMARKETEntities();
            var result = db.PAYMENTS.ToList();
            int salesCount = result.Count;
          
            return salesCount;
        }

        public decimal GetAllMoney()
        {
          //  PROMARKETEntities db = new PROMARKETEntities();
            var result = db.PAYMENTS.ToList();
            decimal totalMoney = (decimal)result.Sum(x => x.PAYMENTTOTAL);
            return totalMoney;
        }
    }

}
