using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dao;
using Entidades;

public partial class EmpleadosWF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnEliminar.Enabled = false;
            int idemp = EmpleadoDao.UltimoIDPrimero();
           
            cargarDDLCargo();
            cargarDDLCargo();
            CargarGrilla();
        }

    }
    protected void gvEmpleados_SelectedIndexChanged(object sender, EventArgs e)
    {
        limpiar();
        ID = int.Parse(gvEmpleados.SelectedDataKey.Value.ToString());

        Empleado emp = EmpleadoDao.obtenerPorId(ID.Value);
        txtNombre.Text = emp.nombre;
        txtApellido.Text = emp.apellido;
        txtFechaNac.Text = emp.fechaNacimiento.ToString("yyyy-MM-dd");
        txtDNI.Text = emp.dni.ToString();
        ddlCargo.SelectedIndex = emp.id_cargo;
        txtCuenta.Text = emp.num_cuenta.ToString();
        chkPedidos.Checked = emp.puede_realizar_pedidos;
        btnEliminar.Enabled = true;
        
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
            return;
        try
        {
            Empleado emp = new Empleado();

           


            emp.nombre = txtNombre.Text;
            emp.apellido = txtApellido.Text;
            emp.fechaNacimiento = Convert.ToDateTime(txtFechaNac.Text);
            emp.dni = Convert.ToInt32(txtDNI.Text);
            emp.id_cargo = ddlCargo.SelectedIndex;
            emp.num_cuenta = Convert.ToInt32(txtCuenta.Text);
            emp.puede_realizar_pedidos = chkPedidos.Checked;

            EmpleadoDao.Insertar(emp);
            limpiar();
            CargarGrilla();
  
  
        }
        catch (Exception ex)
        {
               string script = "alert(\"Ha ocurrido un error del tipo: " + ex.Message + "\");";
              ScriptManager.RegisterStartupScript(this, GetType(),
                  "ServerControlScript", script, true);

            divExcepcion.Visible = true;
            txtExcepcion.Text = ex.Message;
        }
       
            
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

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        limpiar();
        CargarGrilla();
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        if (ID.HasValue)
        {
            EmpleadoDao.eliminar(ID.Value);
            limpiar();
            CargarGrilla();
        }
    }

    protected void cargarDDLCargo()
    {
        string consultaCargo = "Select id_cargo, nombre FROM Cargo";
        ddlCargo.DataSource = EmpleadoDao.leerBD(consultaCargo);
        ddlCargo.DataTextField = "nombre";
        ddlCargo.DataValueField = "id_cargo";
        ddlCargo.DataBind();

        ddlCargo.Items.Insert(0, new ListItem("Seleccione Cargo", "0"));
    }



    protected void limpiar()
    {
        ID = null;
        int ultimo;
        if (EmpleadoDao.UltimoIDPrimero() != 1)
        {
            ultimo = EmpleadoDao.UltimoIDPrimero();
        }
        else
        {
            ultimo = EmpleadoDao.UltimoIDPrimero() - 1;
        }
       
        txtNombre.Text = String.Empty;
        txtApellido.Text = String.Empty;
        txtFechaNac.Text = String.Empty ;
        txtDNI.Text = String.Empty;
        ddlCargo.SelectedIndex = 0;
        txtCuenta.Text = String.Empty;
        chkPedidos.Checked = false;
    }
    protected void CargarGrilla()
    {
        gvEmpleados.DataSource = from emp in EmpleadoQueryDao.ObtenerTodos()
                                 orderby emp.id_empleado
                                 select emp;

        gvEmpleados.DataKeyNames = new String[] { "id_empleado" };
        gvEmpleados.DataBind();
    }

   


}