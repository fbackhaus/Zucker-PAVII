using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Dao;

public partial class ListadoGolosinasWF : System.Web.UI.Page
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
            cargarDDLMarca();
            cargarDDLTipoGolosina();
            cargarDDLEsPropia();
            CargarGrilla(null, null, null, String.Empty);
        }
    }

    protected void cargarDDLEsPropia()
    {
        ddlEsPropia.Items.Insert(0, new ListItem("Todas", "0"));
        ddlEsPropia.Items.Insert(1, new ListItem("Si", "1"));
        ddlEsPropia.Items.Insert(2, new ListItem("No", "2"));
    }
    protected void cargarDDLTipoGolosina()
    {
        ddlTipo.DataSource = GolosinaDao.cargarComboTipo();
        ddlTipo.DataBind();
        ddlTipo.Items.Insert(0, new ListItem("Todas", "0"));
    }
    protected void cargarDDLMarca()
    {
        ddlMarca.DataSource = GolosinaDao.cargarComboMarca();
        ddlMarca.DataBind();

        ddlMarca.Items.Insert(0, new ListItem("Todas", "0"));
    }

    protected void CargarGrilla(int? idMarca, bool? esPropia, int? idTipo, string nombreMP)
    {
        if(GolosinaQueryDao.ObtenerConFiltros(idMarca, esPropia, idTipo, nombreMP).Count == 0)
        {
            lblGolNoEncontrada.Visible = true;
        }
        gvGolosinas.DataSource = from gol in GolosinaQueryDao.ObtenerConFiltros(idMarca, esPropia, idTipo, nombreMP)
                                 orderby gol.id_golosina
                                 select gol;

        gvGolosinas.DataKeyNames = new String[] { "id_golosina" };
        gvGolosinas.DataBind();
    }
    protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
    {
        IDTipo = ddlTipo.SelectedIndex;
        CargarGrilla(IDMarca, esPropia, IDTipo, nombreMP);
    }
    protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
    {
        IDMarca = ddlMarca.SelectedIndex;
        CargarGrilla(IDMarca, esPropia, IDTipo, nombreMP);
    }

    protected int? IDTipo
    {
        get
        {
            if (ViewState["IDTipo"] != null)
                return (int)ViewState["IDTipo"];
            else
                return null;
        }
        set
        {
            ViewState["IDTipo"] = value;
        }
    }

    protected int? IDMarca
    {
        get
        {
            if (ViewState["IDMarca"] != null)
                return (int)ViewState["IDMarca"];
            else
                return null;
        }
        set
        {
            ViewState["IDMarca"] = value;
        }
    }

    protected bool? esPropia
    {
        get
        {
            if (ViewState["EsPropia"] != null)
                return (bool)ViewState["EsPropia"];
            else
                return null;
        }
        set
        {
            ViewState["EsPropia"] = value;
        }
    }

    protected void ddlEsPropia_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selected = ddlEsPropia.SelectedIndex;
        if(selected == 1)
        {
            esPropia = true;
        }
        else if(selected == 2)
        {
            esPropia = false;
        }
        else
        {
            esPropia = null;
        }
        CargarGrilla(IDMarca, esPropia, IDTipo, nombreMP);
    }




    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        nombreMP = txtGolABuscar.Text;
        CargarGrilla(IDMarca, esPropia, IDTipo, nombreMP);
    }

    protected string nombreMP
    {
        get
        {
            if (ViewState["NombreMP"] == null)
                ViewState["NombreMP"] = String.Empty;

            return ViewState["NombreMP"].ToString();
        }
        set { ViewState["NombreMP"] = value; }
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        txtGolABuscar.Text = String.Empty;
        nombreMP = string.Empty;
        CargarGrilla(IDMarca, esPropia, IDTipo, nombreMP);
        lblGolNoEncontrada.Visible = false;
    }
}