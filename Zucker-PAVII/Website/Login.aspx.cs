using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblUsuario.Text = " " + Session["Usuario"].ToString().ToUpper();
        if(!string.IsNullOrEmpty(Session["Usuario"].ToString()))
        {
            divLogin.Visible = false;
        }
    }
        protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (ValidarUsuario(txtUsuario.Text, txtClave.Text))
        {
            Session["Usuario"] = txtUsuario.Text;
            Response.Redirect("Login.aspx");
        }
        else
            Session["Usuario"] = string.Empty;
    }

    private bool ValidarUsuario(string usuario, string clave)
    {
        //LLamar al DAO
        if (usuario.ToUpper() == "JUAN" && clave == "123")
        {            
            List<string> roles = new List<string>();
            roles.Add("Administrador");
            roles.Add("Gerente");
            Session["Roles"] = roles;
            return true;
        }
        else
            return false;
    }
}