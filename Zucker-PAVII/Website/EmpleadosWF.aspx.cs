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
            int idemp = EmpleadoDao.UltimoID();
            cargarDDLCargo();
            cargarDDLCargo();
            CargarGrilla();
        }

    }
    protected void gvEmpleados_SelectedIndexChanged(object sender, EventArgs e)
    {
        limpiar();
        ID = int.Parse(gvEmpleados.SelectedDataKey.Value.ToString());

        Empleado g = EmpleadoDao.obtenerPorId(ID.Value);
        txtNombre.Text = g.nombre;
        txtApellido.Text = g.apellido;
        txtFechaNac.Text = g.fechaNacimiento.ToString("yyyy-MM-dd");
        txtDNI.Text = g.dni.ToString();
        ddlCargo.SelectedIndex = g.id_cargo;
        txtCuenta.Text = g.num_cuenta.ToString();
        chkPedidos.Checked = g.puede_realizar_pedidos;
        btnEliminar.Enabled = true;

    }

    protected void CargarGrilla()
    {
        gvEmpleados.DataSource = from emp in EmpleadoQueryDao.ObtenerTodos()
                                 orderby emp.id_empleado
                                 select emp;

        gvEmpleados.DataKeyNames = new String[] { "id_empleado" };
        gvEmpleados.DataBind();
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
            return;
        try
        {
            Empleado emp = new Empleado();

            //int id_emp;
            //if (int.TryParse(txtIdEmpleado.Text, out id_emp) == true)
            //{
            //    emp.id_empleado = id_emp;
            //}

           // emp.id_empleado = ID.Value ;
            emp.nombre = txtNombre.Text;
            emp.apellido = txtApellido.Text;
            emp.fechaNacimiento = Convert.ToDateTime(txtFechaNac.Text);
            emp.dni = Convert.ToInt32(txtDNI.Text);
            emp.id_cargo = ddlCargo.SelectedIndex;
            emp.num_cuenta = Convert.ToInt32(txtCuenta.Text);
            emp.puede_realizar_pedidos = chkPedidos.Checked;

   //         EmpleadoDao.Insertar(emp);

            if (ID.HasValue)
            {
                emp.id_empleado = ID.Value;
                //ACA AGREGAR EL ACTUALIZAR DEL GOLOSINADAO
                EmpleadoDao.actualizar(emp);
            }
            else
            {
                //GUARDO LA GOLOSINA EN LA BD
                EmpleadoDao.Insertar(emp);
            }
          //  ID = emp.id_empleado.Value;
            CargarGrilla();
        }
        catch (Exception ex)
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
        int ultimo;
        if (EmpleadoDao.UltimoID() != 1)
        {
            ultimo = EmpleadoDao.UltimoID();
        }
        else
        {
            ultimo = EmpleadoDao.UltimoID() - 1;
        }
        txtNombre.Text = String.Empty;
        txtApellido.Text = String.Empty;
        txtFechaNac.Text = String.Empty;
        txtDNI.Text = String.Empty;
        ddlCargo.SelectedIndex = 0;
        txtCuenta.Text = String.Empty;
        chkPedidos.Checked = false;
    }





}