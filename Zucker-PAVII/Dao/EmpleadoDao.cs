using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Dao
{
    class EmpleadoDao
    {
        public static void Insertar(Empleado empleado)
        {
            //1. Abro la Conexion
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=ARMLGLOCCHIPI\SQLEXPRESS;Initial Catalog=BD_Golosinas;Integrated Security=True";
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
            cmd.Parameters.AddWithValue("@Nro_cuenta", empleado.num_cuenta);
            cmd.Parameters.AddWithValue("@Puede_realizar_pedidos", empleado.puede_realizar_pedidos);
            
            cmd.ExecuteNonQuery();

            cn.Close();
        }


        public static int ultimoID()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=ARMLGLOCCHIPI\SQLEXPRESS;Initial Catalog=BD_Golosinas;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Select id_ from Empleado";
            int r = Convert.ToInt32(cmd.ExecuteScalar());
            cn.Close();
            return r;
        }

        public static void actualizarID(int id_empl)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=ARMLGLOCCHIPI\SQLEXPRESS;Initial Catalog=BD_Golosinas;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Update id_empleado set id = @id_empl";
            cmd.Parameters.AddWithValue("@id_gol", id_empl);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public static DataSet leerBD(string consulta)
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=ARMLGLOCCHIPI\SQLEXPRESS;Initial Catalog=BD_Golosinas;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = consulta;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cn.Close();
            return ds;
        }

        public static void actualizar(Empleado empleado)
        {
            //1. Abro la Conexion
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=ARMLGLOCCHIPI\SQLEXPRESS;Initial Catalog=BD_Golosinas;Integrated Security=True";
            cn.Open();
            //2.Creo el objeto command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"update Empleado set nombre = @Nombre,
                                        apellido = @Apellido,
                                        fecha_nacimiento = @Fecha_nacimiento,
                                        dni = @DNI,
                                        id_cargo = @Id_cargo,
                                        nro_cuenta = @Nro_cuenta,
                                        puede_realizar_pedidos = @Puede_realizar_pedidos,
                                        where id_empleado = @Id_Empleado";
            cmd.Parameters.AddWithValue("@Id_Golosina", empleado.id_empleado);
            cmd.Parameters.AddWithValue("@Nombre", empleado.nombre);
            cmd.Parameters.AddWithValue("@Apellido", empleado.apellido);
            cmd.Parameters.AddWithValue("@Fecha_namicmiento",empleado.fechaNacimiento);
            cmd.Parameters.AddWithValue("@DNI", empleado.dni);
            cmd.Parameters.AddWithValue("@Id_cargo", empleado.id_cargo);
            cmd.Parameters.AddWithValue("@nro_cuenta", empleado.num_cuenta);
            cmd.Parameters.AddWithValue("@Puede_realizar_pedidos", empleado.puede_realizar_pedidos);
            

            cmd.ExecuteNonQuery();

            cn.Close();
        }

    }
}
