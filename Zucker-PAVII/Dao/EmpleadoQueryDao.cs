using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;


namespace Dao
{
   public class EmpleadoQueryDao
    {
       public static List<EmpleadoQuery> ObtenerTodos()
       {
           List<EmpleadoQuery> listEmpleados = new List<EmpleadoQuery>();
           EmpleadoQuery e = null;
           SqlConnection cn = new SqlConnection();
           cn.ConnectionString = @"Data Source=FEDE-PC;Initial Catalog=BD_Golosinas;Integrated Security=True";
           cn.Open();
           SqlCommand cmd = new SqlCommand();
           cmd.Connection = cn;
           cmd.CommandText = @"SELECT Empleado.nombre, Empleado.apellido, Empleado.dni, Empleado.fecha_nacimiento,
                                Empleado.puede_realizar_pedidos, Cargo.nombre AS Expr1
                            FROM Cargo INNER JOIN Empleado ON Cargo.id_cargo = Empleado.id_cargo";

           SqlDataReader dr = cmd.ExecuteReader();
           while (dr.Read())
           {
               e = new EmpleadoQuery();
               e.nombre = (dr["nombre"].ToString());
               e.apellido = dr["apellido"].ToString();
               e.numeroDNI = dr["dni"].ToString();
               e.fechaNacimiento = DateTime.Parse(dr["fecha_nacimiento"].ToString());
               e.nombrePedido =dr["puede_realizar_pedidos"].ToString();
               e.nombreCargo = dr["tipo_golosina"].ToString();
               listEmpleados.Add(e);
           }
           dr.Close();
           cn.Close();


           return listEmpleados;
       }

       public static List<EmpleadoQuery> ObtenerConFiltros(int? idCargo, bool? Pedido)
       {
           List<EmpleadoQuery> listEmpleados= new List<EmpleadoQuery>();
           EmpleadoQuery e = null;
           SqlConnection cn = new SqlConnection();
           cn.ConnectionString = @"Data Source=FEDE-PC;Initial Catalog=BD_Golosinas;Integrated Security=True";
           cn.Open();
           SqlCommand cmd = new SqlCommand();
           cmd.Connection = cn;
           cmd.CommandText = @"SELECT Empleado.id_empleado, Empleado.nombre, Empleado.apellido, Empleado.dni, Empleado.fecha_nacimiento, 
                                Empleado.puede_realizar_pedidos, Cargo.nombre as car FROM Cargo INNER JOIN
                                Empleado ON Cargo.id_cargo = Empleado.id_cargo WHERE 1=1";

           if (idCargo.HasValue && idCargo.Value != 0)
           {
               cmd.CommandText += " AND Empleado.id_cargo = @idCargo";
               cmd.Parameters.AddWithValue("@idCargo", idCargo.Value);
           }
           
           if (Pedido.HasValue)
           {
               cmd.CommandText += " AND Empleado.puede_realizar_pedidos = @Pedido";
               cmd.Parameters.AddWithValue("@Pedido", Pedido.Value);
           }
           SqlDataReader dr = cmd.ExecuteReader();
           while (dr.Read())
           {
               e = new EmpleadoQuery();
               e.id_empleado = int.Parse(dr["id_empleado"].ToString());
               e.nombre = (dr["nombre"].ToString());
               e.apellido = dr["apellido"].ToString();
               e.numeroDNI =dr["dni"].ToString();
               e.fechaNacimiento = DateTime.Parse(dr["fecha_nacimiento"].ToString());
               
               e.nombreCargo = dr["car"].ToString();
               e.puede_realizar_pedidos = bool.Parse(dr["puede_realizar_pedidos"].ToString());
               if (e.puede_realizar_pedidos)
                   e.nombrePedido= "Si";
               else
                   e.nombrePedido = "No";
               listEmpleados.Add(e);
           }
           dr.Close();
           cn.Close();


           return listEmpleados;
       }
    }
}
