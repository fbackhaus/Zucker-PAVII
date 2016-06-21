using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Dao;

public partial class CompraAProveedorWF : System.Web.UI.Page
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
            cargarComboProveedor();
            txtFechaCompra.Text = DateTime.Today.ToShortDateString();
            CargarGrilla(id_proveedor, nombreMP);
            Session["ListaDetalles"] = new List<DetalleCompraAProveedor>();
            Cantidad = 1;
        }
    }


    private void cargarComboProveedor()
    {
        ddlProveedor.DataSource = CompraAProveedorDao.cargarComboProveedores();
        ddlProveedor.DataBind();
        ddlProveedor.Items.Insert(0, new ListItem("Todos", "0"));
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        nombreMP = txtMPABuscar.Text;
        CargarGrilla(id_proveedor, nombreMP);
    }
    protected void btnConfirmar_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
            return;

        CompraAProveedor compra = new CompraAProveedor();
        compra.id_compra = CompraAProveedorDao.ultimoIDCompra() + 1;
        Empleado emp = (Empleado)Session["Empleado"];
        compra.id_empleado = emp.id_empleado.Value;
        compra.fecha_compra =DateTime.Parse(txtFechaCompra.Text);
        compra.monto_total = Double.Parse(txtMonto.Text);
        List<DetalleCompraAProveedor> listaDetalles =(List<DetalleCompraAProveedor>)Session["ListaDetalles"];
        CompraAProveedorDao.Insertar(compra, listaDetalles);
        CompraAProveedorDao.actualizarIDCompra(compra.id_compra);

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Pedido Registrado con Exito!')", true);
        Limpiar();

    }
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Limpiar();
    }

    private void Limpiar()
    {
        id_proveedor = null;
        nombreMP = String.Empty;
        ddlProveedor.SelectedIndex = 0;
        txtMPABuscar.Text = String.Empty;
        CargarGrilla(id_proveedor, nombreMP);
        Session["ListaDetalles"] = new List<DetalleCompraAProveedor>();
        gvCompra.DataSource = null;
        gvCompra.DataBind();
        tituloMP.Visible = false;
        txtMonto.Text = "0";
    }

    protected int? id_proveedor
    {
        get
        {
            if (ViewState["Id_Proveedor"] != null)
                return (int)ViewState["Id_Proveedor"];
            else
            {
                return null;
            }
        }
        set { ViewState["Id_Proveedor"] = value; }
    }

    protected int ID
    {
        get
        {
                return (int)ViewState["ID"];
       }
        set { ViewState["ID"] = value; }
    }
    protected int Cantidad
    {
        get
        {
                return (int)ViewState["Cantidad"];
        }
        set { ViewState["Cantidad"] = value; }
    }

    protected string nombreMP
    {
        get
        {
            if(ViewState["NombreMP"] == null)
                ViewState["NombreMP"] = String.Empty;
            
            return ViewState["NombreMP"].ToString();
        }
        set { ViewState["NombreMP"] = value; }
    }


    protected void ddlProveedor_SelectedIndexChanged(object sender, EventArgs e)
    {
        id_proveedor = ddlProveedor.SelectedIndex;
        CargarGrilla(id_proveedor, nombreMP);
    }

    protected void CargarGrilla(int? id_proveedor, string nombreMatPrim)
    {
        if (CompraAProveedorDao.obtenerConFiltros(id_proveedor, nombreMatPrim).Count == 0)
        {
            lblMPNoEncontrada.Visible = true;
        }
        else
        {
            gvMateriasPrimas.DataSource = from detalle in CompraAProveedorDao.obtenerConFiltros(id_proveedor, nombreMatPrim)
                                          orderby detalle.id_materia_prima
                                          select detalle;

            gvMateriasPrimas.DataKeyNames = new String[] { "id_materia_prima" };
            gvCompra.DataKeyNames = new String[] { "id_materia_prima" };
            gvMateriasPrimas.DataBind();
        }

    }

    protected void gvMateriasPrimas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlCantidad = (e.Row.FindControl("ddlCantidad") as DropDownList);
            for (int i = 1; i < 1001; i++)
            {
                ddlCantidad.Items.Add(i.ToString());
            }
            ddlCantidad.DataBind();
        }    

    }

    protected void gvCompra_SelectedIndexChanged(object sender, EventArgs e)
    {
        ID = int.Parse(gvCompra.SelectedDataKey.Value.ToString());
        List<DetalleCompraAProveedor> listaDetalles = (List<DetalleCompraAProveedor>)Session["ListaDetalles"];
        int indice = 0;
        foreach(DetalleCompraAProveedor det in listaDetalles)
        {
            if (det.id_materia_prima == ID)
            {
                indice = listaDetalles.IndexOf(det);
                break;
            }
        }
        DetalleCompraAProveedor detalle = listaDetalles.ElementAt(indice);
        listaDetalles.RemoveAt(indice);
        gvCompra.DataSource = listaDetalles;
        gvCompra.DataBind();
        Session["ListaDetalles"] = listaDetalles;
        double montoTotal = double.Parse(txtMonto.Text);
        montoTotal -= detalle.cantidad * detalle.monto_unitario;
        txtMonto.Text = montoTotal.ToString();
        if(listaDetalles.Count == 0)
        {
            tituloMP.Visible = false;
        }
    }


    protected void gvMateriasPrimas_SelectedIndexChanged(object sender, EventArgs e)
    {
        ID = int.Parse(gvMateriasPrimas.SelectedDataKey.Value.ToString());
        tituloMP.Visible = true;
        List<DetalleCompraAProveedor> listaDetalles =(List<DetalleCompraAProveedor>)Session["ListaDetalles"];
        DetalleCompraAProveedor detalle = CompraAProveedorDao.obtenerPorID(ID);

        detalle.cantidad = Cantidad;
        detalle.stock += detalle.cantidad;  
        listaDetalles.Add(detalle);
        gvCompra.DataSource = listaDetalles;
        gvCompra.DataBind();
        Session["ListaDetalles"] = listaDetalles;
        if (txtMonto.Text == string.Empty)
        {
            txtMonto.Text = (detalle.monto_unitario * detalle.cantidad).ToString();
        }
        else
        {
            double precio = double.Parse(txtMonto.Text) + detalle.monto_unitario * detalle.cantidad;
            txtMonto.Text = precio.ToString();
        }
        
    }
    protected void ddlCantidad_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlCantidad = (DropDownList)sender;
        Cantidad = ddlCantidad.SelectedIndex + 1;
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        txtMPABuscar.Text = String.Empty;
        nombreMP = string.Empty;
        CargarGrilla(id_proveedor, nombreMP);
        lblMPNoEncontrada.Visible = false;
    }
}