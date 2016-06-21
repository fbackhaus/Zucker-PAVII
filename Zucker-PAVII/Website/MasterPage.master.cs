using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Empleado empleado = (Empleado)Session["Empleado"];
        if (empleado != null)
        {
            mnuPedidoAProv.Visible = empleado.puede_realizar_pedidos;
            mnuListadoEmpleados.Visible = true;
            mnuListadoClientes.Visible = true;
            mnuListadoGolosinas.Visible = true;
            mnuGolosinas.Visible = true;
            mnuEmpleados.Visible = true;
        }
        else
        {
            mnuPedidoAProv.Visible = false;
            mnuListadoEmpleados.Visible = false;
            mnuListadoClientes.Visible = false;
            mnuListadoGolosinas.Visible = false;
            mnuGolosinas.Visible = false;
            mnuEmpleados.Visible = false;
        }
        menuRegistrarse.Visible = string.IsNullOrEmpty(Session["Usuario"].ToString());
        mnuLogout.Visible = !string.IsNullOrEmpty(Session["Usuario"].ToString());
        mnuLogin.Visible = string.IsNullOrEmpty(Session["Usuario"].ToString());
    }

}
