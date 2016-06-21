using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Dao;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblUsuario.Text = " " + Session["Usuario"].ToString();
        if(!string.IsNullOrEmpty(Session["Usuario"].ToString()))
        {
            divLogin.Visible = false;
        }
    }
        protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (ValidarEmpleado(txtUsuario.Text, txtClave.Text))
        {
            Response.Redirect("Login.aspx");
        }
        else
            if(ValidarCliente(txtUsuario.Text, txtClave.Text))
            {
                Response.Redirect("Login.aspx");
            }
            else
            Session["Usuario"] = string.Empty;
    }

        private bool ValidarCliente(string usuario, string clave)
        {
            Cliente cliente = ClienteDao.getCliente(usuario, clave);
            if (cliente != null)
            {
                Session["Cliente"] = cliente;
                Session["Usuario"] = cliente.razon_social;
                return true;
            }
            else
                return false;
        }

    private bool ValidarEmpleado(string usuario, string clave)
    {
        Empleado empleado = EmpleadoDao.getEmpleado(usuario, clave);
        if (empleado != null)
        {
            Session["Empleado"] = empleado;
            Session["Usuario"] = empleado.nombre;
            return true;
        }
        else
            return false;
    }
}