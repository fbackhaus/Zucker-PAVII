using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Dao;

public partial class GolosinasWF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            btnEliminar.Enabled = false;
            cargarDDLTipoGolosina();
            cargarDDLMarca();
            CargarGrilla();
        }

    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
            return;
            Golosina g = new Golosina();
            g.id_golosina = GolosinaDao.ultimoID() + 1;
            g.nombre = txtNombre.Text;
            g.id_marca = ddlMarca.SelectedIndex;
            g.id_tipo_golosina = ddlTipo.SelectedIndex;
            g.precio_vta = double.Parse(txtPrecioVta.Text);
            g.descripcion = txtDescripcion.Text;
    /*        int s = int.Parse(txtStock.Text);
            if (s >= 0)
                g.stock = s;
            else
                g.stock = 0;
      */
            g.stock = int.Parse(txtStock.Text);
            g.es_propia = chkEsPropia.Checked;
            g.codigo_producto = int.Parse(txtCodigoProducto.Text);

            if(ID.HasValue)
            {
                g.id_golosina = ID.Value;
                //ACA AGREGAR EL ACTUALIZAR DEL GOLOSINADAO
                GolosinaDao.actualizar(g);
            }
            else
            {
                //GUARDO LA GOLOSINA EN LA BD
               GolosinaDao.Insertar(g);
            }
            ID = g.id_golosina.Value;
            GolosinaDao.actualizarID(g.id_golosina.Value);
            CargarGrilla();
            
    }
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        limpiar();

    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {

    }

    protected int? ID
    {
        get
        {
            if (ViewState["ID"] != null)
                return (int)ViewState["ID"];
            else
            {
                return null;
            }
        }
        set { ViewState["ID"] = value; }
    }

    protected void cargarDDLTipoGolosina()
    {
       string consultaTipo = "Select id_tipo_golosina, nombre FROM Tipo_Golosina";
       ddlTipo.DataSource = GolosinaDao.leerBD(consultaTipo);
       ddlTipo.DataTextField = "nombre";
       ddlTipo.DataValueField = "id_tipo_golosina";
       ddlTipo.DataBind();

     ddlTipo.Items.Insert(0, new ListItem("Seleccione Tipo de Golosina", "0"));
    }
    protected void cargarDDLMarca()
    {
        string consultaMarca = "Select id_marca, nombre FROM Marca";
        ddlMarca.DataSource = GolosinaDao.leerBD(consultaMarca);
        ddlMarca.DataTextField = "nombre";
        ddlMarca.DataValueField = "id_marca";
        ddlMarca.DataBind();

        ddlMarca.Items.Insert(0, new ListItem("Seleccione Marca", "0"));
    }

    protected void limpiar()
    {
        ID = null;
        txtNombre.Text = String.Empty;
        txtDescripcion.Text = String.Empty;
        txtCodigoProducto.Text = String.Empty;
        txtPrecioVta.Text = String.Empty;
        txtStock.Text = String.Empty;
        ddlMarca.SelectedIndex = 0;
        ddlTipo.SelectedIndex = 0;
        chkEsPropia.Checked = false;
    }

    protected void gvGolosinas_SelectedIndexChanged(object sender, EventArgs e)
    {
        limpiar();
        ID = int.Parse(gvGolosinas.SelectedDataKey.Value.ToString());

        Golosina g = GolosinaDao.obtenerPorId(ID.Value);
        txtNombre.Text = g.nombre;
        txtDescripcion.Text = g.descripcion;
        txtCodigoProducto.Text = g.codigo_producto.ToString();
        txtPrecioVta.Text = g.precio_vta.ToString();
        txtStock.Text = g.stock.ToString();
        ddlMarca.SelectedIndex = g.id_marca;
        ddlTipo.SelectedIndex = g.id_tipo_golosina;
        chkEsPropia.Checked = g.es_propia;
    }

    protected void CargarGrilla()
    {
        gvGolosinas.DataSource = from gol in GolosinaQueryDao.ObtenerTodos()
                                 orderby gol.id_golosina
                                 select gol;

        gvGolosinas.DataKeyNames = new String[] { "id_golosina" };
        gvGolosinas.DataBind();
    }
}