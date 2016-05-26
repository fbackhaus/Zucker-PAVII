using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace Dao
{
    class EmpleadoDao
    {
        public static void Insertar(Empleado empleado)
        {
            //1. Abro la Conexion
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=FEDE-PC;Initial Catalog=BD_Golosinas;Integrated Security=True";
            cn.Open();
            //2.Creo el objeto command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"Insert into Empleado (id_empleado,
                                                    nombre,
                                                    apellido,
                                                    fecha_nacimiento,
                                                    dni,
                                                    id_cargo,
                                                    nro_cuenta,
                                                    puede_realizar_pedidos)values (
                                                    @Id_Empleado,
                                                    @Nombre,
                                                    @Apellido,
                                                    @Fecha_nacimiento,
                                                    @Dni,
                                                    @Nro_cuenta,
                                                    @Puede_realizar_pedidos) ; select Scope_Identity() as ID";
            cmd.Parameters.AddWithValue("@Id_Empleado", empleado.id_empleado);
            cmd.Parameters.AddWithValue("@Nombre", empleado.nombre);
            cmd.Parameters.AddWithValue("@Apellido", empleado.apellido);
            cmd.Parameters.AddWithValue("@Fecha_nacimiento", empleado.fechaNacimiento);
            cmd.Parameters.AddWithValue("@Dni", empleado.dni);
            cmd.Parameters.AddWithValue("@Nro_cuenta", empleado.nro_cuenta);
            cmd.Parameters.AddWithValue("@Puede_realizar_pedidos", empleado.puede_realizar_pedidos);
            
            cmd.ExecuteNonQuery();

            cn.Close();
        }
    }
}
