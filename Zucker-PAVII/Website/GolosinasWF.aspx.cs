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
            int idgol = GolosinaDao.ultimoID() + 1;
            txtIdGolosina.Text = idgol.ToString();
            cargarDDLTipoGolosina();
            cargarDDLMarca();
        }

    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
            return;
        try
        {
            Golosina g = new Golosina();
     
            int id_gol;
                if (int.TryParse(txtIdGolosina.Text, out id_gol) == true)
                {
                    g.id_golosina = id_gol;
                }


            
            g.nombre = txtNombre.Text;
            g.id_marca = ddlMarca.SelectedIndex;
            g.id_tipo_golosina = ddlTipo.SelectedIndex;
            g.precio_vta = float.Parse(txtPrecioVta.Text);
            g.descripcion = txtDescripcion.Text;
            int s = int.Parse(txtStock.Text);
            if (s >= 0)
                g.stock = s;
            else
                g.stock = 0;
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
            
        }
        catch(Exception ex)
        {
        //    string script = "alert(\"Ha ocurrido un error del tipo: " + ex.Message + "\");";
          //  ScriptManager.RegisterStartupScript(this, GetType(),
            //                      "ServerControlScript", script, true);

            divExcepcion.Visible = true;
            txtExcepcion.Text = ex.Message;
        }
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
        int ultimo = GolosinaDao.ultimoID() + 1;
        txtIdGolosina.Text = ultimo.ToString();
        txtNombre.Text = String.Empty;
        txtDescripcion.Text = String.Empty;
        txtCodigoProducto.Text = String.Empty;
        txtPrecioVta.Text = String.Empty;
        txtStock.Text = String.Empty;
        ddlMarca.SelectedIndex = 0;
        ddlTipo.SelectedIndex = 0;
        chkEsPropia.Checked = false;
    }

    protected void grdAlumnos_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}