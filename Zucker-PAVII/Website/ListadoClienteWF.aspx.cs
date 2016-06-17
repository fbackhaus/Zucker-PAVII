using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Dao;


public partial class ListadoClienteWF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarDdlLocalidad();
            

            CargarGrilla(null, null);
        }
    }

    protected void CargarGrilla(int? idLoc, DateTime? fecha)
    {
            //FILTROS: POR fecha, POR localidad, POR los que compraron por 1º vez en un periodo
        gvCliente.DataSource = from cli in ClienteQueryDao.SelectConFiltros(idLoc, fecha)
                               orderby cli.id_cliente
                               select cli;
        gvCliente.DataKeyNames=new String[]{"id_cliente"};
        gvCliente.DataBind();
    }

    protected void cargarDdlLocalidad()
    {
        
        ddlLocalidad.DataSource = ClienteDao.cargarComboLocalidad();
        ddlLocalidad.DataBind();

        ddlLocalidad.Items.Insert(0, new ListItem("Todas", "0"));
    }

    protected void ddlLocalidad_SelectedIndexChanged(object sender, EventArgs e)
    {
        IDLoc = ddlLocalidad.SelectedIndex;
        CargarGrilla(IDLoc, Fecha);
    }

    protected int? IDLoc
    {
        get
        {
            if (ViewState["IDLoc"] != null)
                return (int)ViewState["IDLoc"];
            else
                return null;
        }
        set
        {
            ViewState["IDLoc"] = value;
        }
    }
    protected DateTime? Fecha
    {
        get
        {
            if (ViewState["Fecha"] != null)
                return (DateTime)ViewState["Fecha"];
            else
                return null;
        }
        set
        {
            ViewState["Fechas"] = value;
        }
    }
    protected void btnFecha_Click(object sender, EventArgs e)
    {
        Fecha = DateTime.Parse(txtFechaFundacion.Text);
        CargarGrilla(IDLoc, Fecha);
    }
}