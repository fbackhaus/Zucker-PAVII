using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Dao;

public partial class LoteDeProduccionWF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool acceso = false;
        if (Session["Empleado"] != null)
        {
            acceso = true;
        }
        if (!acceso) Response.Redirect("Login.aspx");

        if (Session["Usuario"] == string.Empty)
        {
            //Usuario Anónimo
            Response.Redirect("Login.aspx");
        }
    }
  
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        
    }
    protected void btnNuevo_Click(object sender, EventArgs e)
    {

    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {

    }
    protected void gvLotes_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlEmpleado_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}