﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Dao
{
    public class EmpleadoDao
    {
        public static void Insertar(Empleado empleado)
        {
            //1. Abro la Conexion
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=FEDE-PC;Initial Catalog=BD_Golosinas;Integrated Security=True";
            cn.Open();
            //2.Creo el objeto command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"Insert into Empleado (nombre,
                                                    apellido,
                                                    fecha_nacimiento,
                                                    dni,
                                                    nro_cuenta,
                                                    id_cargo,
                                                    puede_realizar_pedidos)values (
                                                    @Nombre,
                                                    @Apellido,
                                                    @Fecha_nacimiento,
                                                    @Dni,
                                                    @Nro_cuenta,
                                                    @Id_Cargo,
                                                    @Puede_realizar_pedidos) ; select Scope_Identity() as ID";
            //  cmd.Parameters.AddWithValue("@Id_Empleado", empleado.id_empleado);
            cmd.Parameters.AddWithValue("@Nombre", empleado.nombre);
            cmd.Parameters.AddWithValue("@Apellido", empleado.apellido);
            cmd.Parameters.AddWithValue("@Fecha_nacimiento", empleado.fechaNacimiento);
            cmd.Parameters.AddWithValue("@Dni", empleado.dni);
            cmd.Parameters.AddWithValue("@Nro_cuenta", empleado.num_cuenta);
            cmd.Parameters.AddWithValue("@Id_Cargo", empleado.id_cargo);
            cmd.Parameters.AddWithValue("@Puede_realizar_pedidos", empleado.puede_realizar_pedidos);

            cmd.ExecuteNonQuery();

            cn.Close();
        }


        public static int UltimoID()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=FEDE-PC;Initial Catalog=BD_Golosinas;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "SELECT ISNULL(MAX(id_empleado), 0) AS ID FROM Empleado";
            int r = Convert.ToInt32(cmd.ExecuteScalar());
            cn.Close();

            return r + 1;
        }




        public static DataSet leerBD(string consulta)
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=FEDE-PC;Initial Catalog=BD_Golosinas;Integrated Security=True";
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
            cn.ConnectionString = @"Data Source=FEDE-PC;Initial Catalog=BD_Golosinas;Integrated Security=True";
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
                                        puede_realizar_pedidos = @Puede_realizar_pedidos
                                        where id_empleado = @Id_Empleado";
            cmd.Parameters.AddWithValue("@Id_Empleado", empleado.id_empleado);
            cmd.Parameters.AddWithValue("@Nombre", empleado.nombre);
            cmd.Parameters.AddWithValue("@Apellido", empleado.apellido);
            cmd.Parameters.AddWithValue("@Fecha_nacimiento", empleado.fechaNacimiento);
            cmd.Parameters.AddWithValue("@DNI", empleado.dni);
            cmd.Parameters.AddWithValue("@Id_cargo", empleado.id_cargo);
            cmd.Parameters.AddWithValue("@Nro_cuenta", empleado.num_cuenta);
            cmd.Parameters.AddWithValue("@Puede_realizar_pedidos", empleado.puede_realizar_pedidos);


            cmd.ExecuteNonQuery();

            cn.Close();
        }

        public static void eliminar(int id)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=FEDE-PC;Initial Catalog=BD_Golosinas;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Delete FROM Empleado Where id_empleado = @idemp";
            cmd.Parameters.AddWithValue("@idemp", id);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public static Empleado obtenerPorId(int id)
        {
            Empleado g = null;
            SqlConnection cn = new SqlConnection(@"Data Source=FEDE-PC;Initial Catalog=BD_Golosinas;Integrated Security=True");
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"Select id_empleado, nombre, apellido , fecha_nacimiento, dni, id_cargo, nro_cuenta,
                                 puede_realizar_pedidos FROM Empleado Where id_empleado = @id_emp";
            cmd.Parameters.AddWithValue("@id_emp", id);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                g = new Empleado();
                g.id_empleado = int.Parse(dr["id_empleado"].ToString());
                g.nombre = dr["nombre"].ToString();
                g.apellido = dr["apellido"].ToString();
                g.fechaNacimiento = DateTime.Parse(dr["fecha_nacimiento"].ToString());
                g.dni = int.Parse(dr["dni"].ToString());
                g.id_cargo = int.Parse(dr["id_cargo"].ToString());
                g.num_cuenta = int.Parse(dr["nro_cuenta"].ToString());
                g.puede_realizar_pedidos = bool.Parse(dr["puede_realizar_pedidos"].ToString());

            }
            dr.Close();
            cn.Close();
            return g;
        }


        public static Empleado getEmpleado(string usuario, string clave)
        {
            Empleado e = null;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=FEDE-PC;Initial Catalog=BD_Golosinas;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"Select e.id_empleado, e.nombre, e.apellido, e.fecha_nacimiento, e.dni, e.id_cargo, e.nro_cuenta, e.puede_realizar_pedidos
                                FROM  Empleado e INNER JOIN Cuenta c ON e.nro_cuenta = c.nro_cuenta
                                WHERE c.usuario = @Usuario AND c.contraseña = @Clave";
            cmd.Parameters.AddWithValue("@Usuario", usuario);
            cmd.Parameters.AddWithValue("@Clave", clave);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                e = new Empleado();
                e.id_empleado = int.Parse(dr["id_empleado"].ToString());
                e.nombre = dr["nombre"].ToString();
                e.apellido = dr["apellido"].ToString();
                e.fechaNacimiento = DateTime.Parse(dr["fecha_nacimiento"].ToString());
                e.dni = int.Parse(dr["dni"].ToString());
                e.id_cargo = int.Parse(dr["id_cargo"].ToString());
                e.num_cuenta = int.Parse(dr["nro_cuenta"].ToString());
                e.puede_realizar_pedidos = bool.Parse(dr["puede_realizar_pedidos"].ToString());
            }

            dr.Close();
            cn.Close();
            return e;
        }
    }
}
