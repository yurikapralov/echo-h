using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PayMethods : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.Title =
               "Способы оплаты";
        Master.MainHeader = "Способы оплаты";
    }
}