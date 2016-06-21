using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Dao;

public partial class ClienteWF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            btmEliminar.Enabled = false;
            cargarDDLLocalidad();
            cbPrimeraCompra.Checked = true;
            cbPrimeraCompra.Enabled = false;
            cargarGrilla();
        }
    }

    protected void cargarDDLLocalidad()
    {
        
        ddlLocalidad.DataSource = ClienteDao.cargarComboLocalidad();
        ddlLocalidad.DataBind();

        ddlLocalidad.Items.Insert(0, new ListItem("Seleccione una Localidad", "0"));
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) { return; }
        
            Cliente cli = new Cliente();
            cli.id_cliente = ClienteDao.traerUltimoID() + 1;
            cli.cuit = txtCUIT.Text;
            cli.razon_social = txtRazonSocial.Text;
            cli.calle = txtCalle.Text;
            cli.numero = int.Parse(txtNro.Text);

            if (String.IsNullOrEmpty(txtPiso.Text))
            {
                cli.piso = 99;
            }else
            {
                cli.piso = int.Parse(txtPiso.Text);
            }

            if (String.IsNullOrEmpty(txtDpto.Text)) { cli.dpto = "ZZ"; } else { cli.dpto = (txtDpto.Text); }
            
            cli.codigo_postal = int.Parse(txtCP.Text);
            cli.telefono = txtTelefono.Text;
            cli.email = txtEmail.Text;
            cli.id_localidad = (ddlLocalidad.SelectedIndex);
            cli.fecha_fundacion = DateTime.Parse(txtFechaFundacion.Text);
            cli.nro_cuenta = double.Parse(txtNroCuenta.Text);
            cli.es_primera_vez = cbPrimeraCompra.Checked;


        if (ID.HasValue)
        {
            cli.id_cliente = ID.Value;
            ClienteDao.actualizar(cli);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Cliente exitosamente modificado')", true);
        }else
        {
            ClienteDao.Insertar(cli);
            ClienteDao.actualizarID(cli.id_cliente);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Cliente guardado')", true);
        }
        ID = cli.id_cliente;
        cargarGrilla();
        limpiar();
            

        //cbPrimeraCompra.Checked = false;
        cbPrimeraCompra.Enabled = false;
        
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        limpiar();
    }

    protected void btmEliminar_Click(object sender, EventArgs e)
    {
        if (ID.HasValue)
        {
            ClienteDao.eliminar(ID.Value);
            limpiar();
            cargarGrilla();
        }
    }

    protected void cargarGrilla()
    {
        gvClientes.DataSource = from cli in ClienteQueryDao.Select()
                                orderby cli.id_cliente
                                select cli;
        gvClientes.DataKeyNames = new String[] { "id_cliente" };
        gvClientes.DataBind();
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


    protected void limpiar()
    {
        ID = null;
        txtRazonSocial.Text = String.Empty;
        txtCUIT.Text = String.Empty;
        txtCalle.Text= String.Empty;
        txtNro.Text= String.Empty;
        txtPiso.Text=String.Empty;
        txtDpto.Text= String.Empty;
        txtCP.Text= String.Empty;
        ddlLocalidad.SelectedIndex = 0;
        txtTelefono.Text= String.Empty;
        txtEmail.Text= String.Empty;
        txtFechaFundacion.Text= String.Empty;
        txtNroCuenta.Text= String.Empty;
        cbPrimeraCompra.Checked = false;
        btmEliminar.Enabled = false;
    }



    protected void gvClientes_SelectedIndexChanged(object sender, EventArgs e)
    {
        limpiar();
        ID = int.Parse(gvClientes.SelectedDataKey.Value.ToString());

        Cliente c = ClienteDao.ObtenerPorID(ID.Value);
        txtRazonSocial.Text = c.razon_social;
        txtCUIT.Text = c.cuit;
        txtCalle.Text = c.calle;
        txtNro.Text = c.numero.ToString();
        txtPiso.Text = c.piso.ToString();
        txtDpto.Text = c.dpto;
        txtCP.Text = c.codigo_postal.ToString();
        ddlLocalidad.SelectedIndex= c.id_localidad;
        txtTelefono.Text = c.telefono;
        txtEmail.Text = c.email;
        txtFechaFundacion.Text = c.fecha_fundacion.ToString("yyyy-MM-dd");
        txtNroCuenta.Text = c.nro_cuenta.ToString();
        cbPrimeraCompra.Checked = c.es_primera_vez;

        btmEliminar.Enabled = true;
    }
}