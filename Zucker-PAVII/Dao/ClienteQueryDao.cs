using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;


namespace Dao
{
    public class ClienteQueryDao
    {
        static string cadena_de_conexion = @"Data Source=ARMLGLOCCHIPI\SQLEXPRESS;Initial Catalog=BD_Golosinas;Integrated Security=True";

        public static List<ClienteQuery> Select()
        {
            List<ClienteQuery> lista = new List<ClienteQuery>();
            ClienteQuery c = null;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cadena_de_conexion;
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT c.id_cliente, c.cuit, c.razon_social, c.fecha_fundacion, c.email, c.telefono, c.calle, c.numero,
                                       c.piso, c.dpto, l.nombre as loc, c.codigo_postal, c.nro_cuenta, c.es_primera_vez
                                FROM Cliente c INNER JOIN Localidad l ON c.id_localidad = l.id_localidad";

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                c = new ClienteQuery();

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
                c.nombreLocalidad = (dr["loc"].ToString());
                c.codigo_postal = int.Parse(dr["codigo_postal"].ToString());
                c.nro_cuenta = int.Parse(dr["nro_cuenta"].ToString());
                c.es_primera_vez = bool.Parse(dr["es_primera_vez"].ToString());


                lista.Add(c);
            }
            dr.Close();
            cn.Close();

            return lista;
        }


        public static List<ClienteQuery> SelectConFiltros(int? idLoc, DateTime? date)
        {
            List<ClienteQuery> listaCl = new List<ClienteQuery>();
            ClienteQuery c = null;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cadena_de_conexion;
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT c.id_cliente, c.cuit, c.razon_social, c.fecha_fundacion, c.email, c.telefono, c.calle, c.numero,
                                       c.piso, c.dpto, l.nombre as loc, c.codigo_postal, c.nro_cuenta, c.es_primera_vez
                                FROM Cliente c INNER JOIN Localidad l ON c.id_localidad = l.id_localidad
                                WHERE 2=2";
            if (idLoc.HasValue && idLoc.Value != 0)
            {
                cmd.CommandText += " AND c.id_localidad = @idLocalidad";
                cmd.Parameters.AddWithValue("@idLocalidad", idLoc.Value);
            }
            if(date.HasValue)
            {
                cmd.CommandText += " AND c.fecha_fundacion = '2013-10-30'";
                cmd.Parameters.AddWithValue("@Fecha", date);
            }

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                c = new ClienteQuery();

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
                c.nombreLocalidad = (dr["loc"].ToString());
                c.codigo_postal = int.Parse(dr["codigo_postal"].ToString());
                c.nro_cuenta = int.Parse(dr["nro_cuenta"].ToString());
                c.es_primera_vez = bool.Parse(dr["es_primera_vez"].ToString());


                listaCl.Add(c);
            }
            dr.Close();
            cn.Close();

            return listaCl;
            
        }


    }
}
