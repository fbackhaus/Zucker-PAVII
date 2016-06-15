using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        mnuListadoGolosinas.Visible = !string.IsNullOrEmpty(Session["Usuario"].ToString());
        mnuLogout.Visible = !string.IsNullOrEmpty(Session["Usuario"].ToString());
        mnuLogin.Visible = string.IsNullOrEmpty(Session["Usuario"].ToString());
        mnuGolosinas.Visible = !string.IsNullOrEmpty(Session["Usuario"].ToString());
        mnuEmpleados.Visible = !string.IsNullOrEmpty(Session["Usuario"].ToString());
    }

}
