using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;

public partial class GolosinasWF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            btnEliminar.Enabled = false;
        }
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
            return;
        try
        {
            Golosina g = new Golosina();
            g.id_golosina = int.Parse(txtIdGolosina.Text);
            
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
            }
            else
            {
                //ACA AGREGAR EL GUARDAR DEL GOLOSINADAO
            }
            ID = g.id_golosina.Value;
            txtDescripcion.Text = "ANDUVO PA";
            
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
}