﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Usuario"] = string.Empty;
        Session["Cliente"] = null;
        Session["Empleado"] = null;
        Response.Redirect("Login.aspx");
    }
}