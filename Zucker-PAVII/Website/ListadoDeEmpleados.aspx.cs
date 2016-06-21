using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dao;
using Entidades;

public partial class ListadoDeEmpleados : System.Web.UI.Page
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
        if(!Page.IsPostBack)
        {
            cargarDDLCargo();
            cargarDDLPedidos();
            CargarGrilla(null, null);
        }
        
    }


   

    protected void cargarDDLPedidos()
    {
        ddlPedidos.Items.Insert(0, new ListItem("Todas", "0"));
        ddlPedidos.Items.Insert(1, new ListItem("Si", "1"));
        ddlPedidos.Items.Insert(2, new ListItem("No", "2"));
    }

    protected void cargarDDLCargo()
    {
        string consultaTipo = "Select id_cargo, nombre FROM Cargo";
        ddlCargo.DataSource = EmpleadoDao.leerBD(consultaTipo);
        ddlCargo.DataTextField = "nombre";
        ddlCargo.DataValueField = "id_cargo";
        ddlCargo.DataBind();

        ddlCargo.Items.Insert(0, new ListItem("Todas", "0"));
    }

    protected void CargarGrilla(int? idCargo, bool? Pedido)
    {
        gvEmpleados.DataSource = from emp in EmpleadoQueryDao.ObtenerConFiltros(idCargo, Pedido)
                                 orderby emp.id_empleado
                                 select emp;
        

        gvEmpleados.DataKeyNames = new String[] { "id_empleado" };
        gvEmpleados.DataBind();
    }


    protected int? idCargo
    {
        get
        {
            if (ViewState["idCargo"] != null)
                return (int)ViewState["idCargo"];
            else
                return null;
        }
        set
        {
            ViewState["idCargo"] = value;
        }
    }

    protected bool? Pedido
    {
        get
        {
            if (ViewState["Pedido"] != null)
                return (bool)ViewState["Pedido"];
            else
                return null;
        }
        set
        {
            ViewState["Pedido"] = value;
        }
    }


    protected void ddlPedidos_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selected = ddlPedidos.SelectedIndex;
        if (selected == 1)
        {
            Pedido = true;
        }
        else if (selected == 2)
        {
            Pedido = false;
        }
        else
        {
            Pedido = null;
        }
        CargarGrilla(idCargo, Pedido);
    }
    protected void ddlCargo_SelectedIndexChanged(object sender, EventArgs e)
    {
        int seleccion = ddlCargo.SelectedIndex;
        CargarGrilla(seleccion, Pedido);
    }
}