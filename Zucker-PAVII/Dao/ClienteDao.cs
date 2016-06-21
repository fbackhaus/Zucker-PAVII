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
    public class ClienteDao
    {
        static string cadena_de_conexion = @"Data Source=LUCA\SQLSERVER;Initial Catalog=BD_Golosinas;Integrated Security=True";
        static string tablas = "id_cliente, cuit, razon_social, fecha_fundacion, email, telefono, calle, numero, piso, dpto, id_localidad, codigo_postal, nro_cuenta, es_primera_vez";
        static string valoresParametros = "@id_cliente, @cuit,@razon_social,@fecha_fundacion,@email,@telefono, @calle,@numero,@piso,@dpto,@id_localidad,@codigo_postal,@nro_cuenta,@es_primera_vez";
        
        public static void Insertar (Cliente cli)
        {
            //1-Abro la conexion
            SqlConnection cn = new SqlConnection();
            //cn.ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\BD_Golosinas1.mdf;Integrated Security=True;Connect Timeout=30";
            cn.ConnectionString = cadena_de_conexion;
            //cn.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=BD_Golosinas1;Integrated Security=True";
            cn.Open();

            //2-Creo el objeto command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"INSERT INTO CLIENTE (" + tablas + ") values (" + valoresParametros + ")";
            
            cmd.Parameters.AddWithValue("@id_cliente", cli.id_cliente);
            cmd.Parameters.AddWithValue("@cuit", cli.cuit);
            cmd.Parameters.AddWithValue("@razon_social", cli.razon_social);
            cmd.Parameters.AddWithValue("@fecha_fundacion", cli.fecha_fundacion);
            cmd.Parameters.AddWithValue("@email", cli.email);
            cmd.Parameters.AddWithValue("@telefono", cli.telefono);
            cmd.Parameters.AddWithValue("@calle", cli.calle);
            cmd.Parameters.AddWithValue("@numero", cli.numero);
            cmd.Parameters.AddWithValue("@piso", cli.piso);
            cmd.Parameters.AddWithValue("@dpto", cli.dpto);
            cmd.Parameters.AddWithValue("@id_localidad", cli.id_localidad);
            cmd.Parameters.AddWithValue("@codigo_postal", cli.codigo_postal);
            cmd.Parameters.AddWithValue("@nro_cuenta", cli.nro_cuenta);
            cmd.Parameters.AddWithValue("@es_primera_vez", cli.es_primera_vez);
            
            cmd.ExecuteNonQuery();
            cn.Close(); 
        }

        public static void actualizar(Cliente cli)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cadena_de_conexion;
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"UPDATE Cliente SET 
                                                cuit = @cuit,
                                                razon_social = @razon_social, 
                                                fecha_fundacion = @fecha_fundacion, 
                                                email = @email, 
                                                telefono = @telefono, 
                                                calle = @calle, 
                                                numero = @numero, 
                                                piso = @piso,
                                                dpto = @dpto, 
                                                id_localidad = @id_localidad, 
                                                codigo_postal = @codigo_postal,
                                                nro_cuenta = @nro_cuenta, 
                                                es_primera_vez = @es_primera_vez
                                                where id_cliente = @id_cliente";

            cmd.Parameters.AddWithValue("@id_cliente", cli.id_cliente);
            cmd.Parameters.AddWithValue("@cuit", cli.cuit);
            cmd.Parameters.AddWithValue("@razon_social", cli.razon_social);
            cmd.Parameters.AddWithValue("@fecha_fundacion", cli.fecha_fundacion);
            cmd.Parameters.AddWithValue("@email", cli.email);
            cmd.Parameters.AddWithValue("@telefono", cli.telefono);
            cmd.Parameters.AddWithValue("@calle", cli.calle);
            cmd.Parameters.AddWithValue("@numero", cli.numero);
            cmd.Parameters.AddWithValue("@piso", cli.piso);
            cmd.Parameters.AddWithValue("@dpto", cli.dpto);
            cmd.Parameters.AddWithValue("@id_localidad", cli.id_localidad);
            cmd.Parameters.AddWithValue("@codigo_postal", cli.codigo_postal);
            cmd.Parameters.AddWithValue("@nro_cuenta", cli.nro_cuenta);
            cmd.Parameters.AddWithValue("@es_primera_vez", cli.es_primera_vez);

            cmd.ExecuteNonQuery();
            cn.Close();

        }

        public static Cliente ObtenerPorID(int value)
        {
            Cliente c = null;
            SqlConnection cn = new SqlConnection(cadena_de_conexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"Select * FROM Cliente WHERE id_cliente = @id_cli";
            cmd.Parameters.AddWithValue("@id_cli", value);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = new Cliente();
                c.id_cliente = int.Parse(dr["id_cliente"].ToString());
                c.cuit = (dr["cuit"].ToString());
                c.razon_social = (dr["razon_social"].ToString());
                c.fecha_fundacion = DateTime.Parse(dr["fecha_fundacion"].ToString());
                c.email = (dr["email"].ToString());
                c.telefono = (dr["telefono"].ToString());
                c.calle = (dr["calle"].ToString());
                c.numero = int.Parse(dr["numero"].ToString());
                c.piso = int.Parse(dr["piso"].ToString());
                c.dpto = (dr["dpto"].ToString());
                c.id_localidad = int.Parse(dr["id_localidad"].ToString());
                c.codigo_postal = int.Parse(dr["codigo_postal"].ToString());
                c.nro_cuenta = int.Parse(dr["nro_cuenta"].ToString());
                c.es_primera_vez = bool.Parse(dr["es_primera_vez"].ToString());
                

            }
            return c;
        }

        public static void eliminar(int value)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cadena_de_conexion;
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "DELETE FROM Cliente WHERE id_cliente = @id_cli";
            cmd.Parameters.AddWithValue("@id_cli", value);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public static int traerUltimoID()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cadena_de_conexion;
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "SELECT idCli FROM ID_CLIENTESS";
            int r = Convert.ToInt32(cmd.ExecuteScalar());
            cn.Close();
            return r;
        }

        public static void actualizarID(int id_cli)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cadena_de_conexion;
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "UPDATE ID_CLIENTESS SET idCli = @id_cli";
            cmd.Parameters.AddWithValue("@id_cli", id_cli);
            cmd.ExecuteNonQuery();
            cn.Close();
        }


        public static List<String> cargarComboLocalidad()
        {
            List<String> lista = new List<string>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cadena_de_conexion;
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "SELECT id_localidad, nombre FROM Localidad";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(dr["nombre"].ToString());
            }
            dr.Close();
            cn.Close();
            return lista;
        }

        public static Cliente getCliente(string usuario, string clave)
        {
            Cliente c = null;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=LUCA\SQLSERVER;Initial Catalog=BD_Golosinas;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"Select c.id_cliente, c.cuit, c.razon_social, c.fecha_fundacion, c.email, c.telefono, c.calle,
                                c.numero, c.piso, c.dpto, c.id_localidad, c.codigo_postal, c.nro_cuenta, c.es_primera_vez
                                FROM Cliente c INNER JOIN Cuenta cu ON c.nro_cuenta = cu.nro_cuenta 
                                WHERE cu.usuario = @Usuario AND cu.contraseña = @Clave";
            cmd.Parameters.AddWithValue("@Usuario", usuario);
            cmd.Parameters.AddWithValue("@Clave", clave);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = new Cliente();
                c.id_cliente = int.Parse(dr["id_cliente"].ToString());
                c.cuit = (dr["cuit"].ToString());
                c.razon_social = (dr["razon_social"].ToString());
                c.fecha_fundacion = DateTime.Parse(dr["fecha_fundacion"].ToString());
                c.email = (dr["email"].ToString());
                c.telefono = (dr["telefono"].ToString());
                c.calle = (dr["calle"].ToString());
                c.numero = int.Parse(dr["numero"].ToString());
                //c.piso = int.Parse(dr["piso"].ToString());
                //c.dpto = (dr["dpto"].ToString());
                c.id_localidad = int.Parse(dr["id_localidad"].ToString());
                c.codigo_postal = int.Parse(dr["codigo_postal"].ToString());
                c.nro_cuenta = int.Parse(dr["nro_cuenta"].ToString());
                c.es_primera_vez = bool.Parse(dr["es_primera_vez"].ToString());
            }

            dr.Close();
            cn.Close();
            return c;
        }
    }
}
