using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Dao;

public partial class LoteDeProduccionWF : System.Web.UI.Page
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
            cargarGrillaGolosinas();
            Session["ListaDetalles"] = new List<DetalleProduccion>();
            Cantidad = 1;
        }

    }




        protected void cargarGrillaGolosinas()
        {
        
        gvGolosinas.DataSource = from gol in GolosinaQueryDao.obtenerPropias()
                                 orderby gol.id_golosina
                                 select gol;

        gvGolosinas.DataKeyNames = new String[] { "id_golosina" };
        gvGolosinas.DataBind();

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

        protected string nombreGol
        {
            get
            {
                if (ViewState["NombreGol"] == null)
                    ViewState["NombreGol"] = String.Empty;

                return ViewState["NombreGol"].ToString();
            }
            set { ViewState["NombreGol"] = value; }
        }




        protected void gvGolosinas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ID = int.Parse(gvGolosinas.SelectedDataKey.Value.ToString());
            tituloMP.Visible = true;
            List<DetalleProduccion> listaDetalles = (List<DetalleProduccion>)Session["ListaDetalles"];
            DetalleProduccion detalle = LoteProduccionDao.obtenerPorID(ID);

            detalle.cantidad = Cantidad;
            detalle.stock += detalle.cantidad;
            listaDetalles.Add(detalle);
            gvACargar.DataSource = listaDetalles;
            gvACargar.DataBind();
            Session["ListaDetalles"] = listaDetalles;
        }


        protected void gvGolosinas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlCantidad = (e.Row.FindControl("ddlCantidad") as DropDownList);
                for (int i = 1; i < 1001; i++)
                {
                    ddlCantidad.Items.Add(i.ToString());
                }
                ddlCantidad.DataBind();
            }    
        }


        protected void ddlCantidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlCantidad = (DropDownList)sender;
            Cantidad = ddlCantidad.SelectedIndex + 1;
        }


        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = String.Empty;
            nombreGol = string.Empty;
            cargarGrillaGolosinas();
            lblNoEncontrada.Visible = false;
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            nombreGol = txtBuscar.Text;
            cargarGrilla(nombreGol);

        }


       
        protected void gvACargar_SelectedIndexChanged(object sender, EventArgs e)
        {
            ID = int.Parse(gvACargar.SelectedDataKey.Value.ToString());
            List<DetalleProduccion> listaDetalles = (List<DetalleProduccion>)Session["ListaDetalles"];
            int indice = 0;
            foreach (DetalleProduccion det in listaDetalles)
            {
                if (det.id_golosina == ID)
                {
                    indice = listaDetalles.IndexOf(det);
                    break;
                }
            }
            DetalleProduccion detalle = listaDetalles.ElementAt(indice);
            listaDetalles.RemoveAt(indice);
            gvACargar.DataSource = listaDetalles;
            gvACargar.DataBind();
            Session["ListaDetalles"] = listaDetalles;

            
            
            ;
            if (listaDetalles.Count == 0)
            {
                tituloMP.Visible = false;
            }

        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {

        }
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            LoteProduccion lote = new LoteProduccion();
            lote.codLote = LoteProduccionDao.ultimoIDCompra() + 1;
            Empleado emp = (Empleado)Session["Empleado"];
            lote.id_empleado = emp.id_empleado.Value;
            lote.fecha = DateTime.Parse(txtFecha.Text);
            List<DetalleProduccion> listaDetalles = (List<DetalleProduccion>)Session["ListaDetalles"];
            LoteProduccionDao.Insertar(lote, listaDetalles);
         

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Pedido Registrado con Exito!')", true);
            Limpiar();


        }


        protected void cargarGrilla(string nombreGol)
        {
            gvGolosinas.DataSource = from gol in GolosinaQueryDao.ObtenerPorNombre(nombreGol)
                                     orderby gol.nombre
                                     select gol;
            gvGolosinas.DataBind();

        }
        protected void gvGolosinas_DataBound(object sender, EventArgs e)
        {

        }

    private void Limpiar()
    {
        ID = 0;
        nombreGol = String.Empty;
        
        txtBuscar.Text = String.Empty;
        
        Session["ListaDetalles"] = new List<DetalleCompraAProveedor>();
        gvACargar.DataSource = null;
        gvACargar.DataBind();
        tituloMP.Visible = false;
        
    }
}