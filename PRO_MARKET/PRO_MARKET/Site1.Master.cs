using Proje.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRO_MARKET
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //List<Months> months = new List<Months>();
            //Months months1 = new Months();

            //months1.MonthName = "Month ";
            //    months1.MontId = 1;
            //    months.Add(months1);
            

            //tableRepeater.DataSource = months;
            //tableRepeater.DataBind();
            //asjdls.DataSource = deneme.ToList();
            //asjdls.DataBind();
           // ScriptManager.RegisterStartupScript(GetType(), "Javascript", "javascript:FUNCTIONNAME(); ", true);
        }

        class Months
        {
            public int MontId { get; set; }
            public string MonthName { get; set; }
        }

    }
}