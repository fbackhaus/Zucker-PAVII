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
        if(!Page.IsPostBack)
        {
            cargarDDLMarca();
            cargarDDLTipoGolosina();
            cargarDDLEsPropia();
            CargarGrilla(null, null, null);
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
        string consultaTipo = "Select id_tipo_golosina, nombre FROM Tipo_Golosina";
        ddlTipo.DataSource = GolosinaDao.leerBD(consultaTipo);
        ddlTipo.DataTextField = "nombre";
        ddlTipo.DataValueField = "id_tipo_golosina";
        ddlTipo.DataBind();

        ddlTipo.Items.Insert(0, new ListItem("Todas", "0"));
    }
    protected void cargarDDLMarca()
    {
        string consultaMarca = "Select id_marca, nombre FROM Marca";
        ddlMarca.DataSource = GolosinaDao.leerBD(consultaMarca);
        ddlMarca.DataTextField = "nombre";
        ddlMarca.DataValueField = "id_marca";
        ddlMarca.DataBind();

        ddlMarca.Items.Insert(0, new ListItem("Todas", "0"));
    }

    protected void CargarGrilla(int? idMarca, bool? esPropia, int? idTipo)
    {
        gvGolosinas.DataSource = from gol in GolosinaQueryDao.ObtenerConFiltros(idMarca, esPropia, idTipo)
                                 orderby gol.id_golosina
                                 select gol;

        gvGolosinas.DataKeyNames = new String[] { "id_golosina" };
        gvGolosinas.DataBind();
    }
    protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
    {
        IDTipo = ddlTipo.SelectedIndex;
        CargarGrilla(IDMarca, esPropia, IDTipo);
    }
    protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
    {
        IDMarca = ddlMarca.SelectedIndex;
        CargarGrilla(IDMarca, esPropia, IDTipo);
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
        CargarGrilla(IDMarca, esPropia, IDTipo);
    }
}