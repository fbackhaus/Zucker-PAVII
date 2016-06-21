using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;
namespace Dao
{
    public class GolosinaQueryDao
    {
        public static List<GolosinaQuery> ObtenerTodos()
        {
            List<GolosinaQuery> listGolosinas = new List<GolosinaQuery>();
            GolosinaQuery g = null;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=LUCA\SQLSERVER;Initial Catalog=BD_Golosinas;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"Select g.id_golosina, g.nombre, g.descripcion, m.nombre as marca, g.stock, t.nombre as tipo_golosina, g.precio_vta, g.es_propia, g.codigo_barras
                                From Golosina g INNER JOIN Marca m ON g.id_marca = m.id_marca 
                                INNER JOIN Tipo_Golosina t ON g.id_tipo_golosina = t.id_tipo_golosina";

            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                g = new GolosinaQuery();
                g.id_golosina = int.Parse(dr["id_golosina"].ToString());
                g.nombre = dr["nombre"].ToString();
                g.descripcion = dr["descripcion"].ToString();
                g.nombreMarca = dr["marca"].ToString();
                g.stock = int.Parse(dr["stock"].ToString());
                g.nombreTipoGolosina = dr["tipo_golosina"].ToString();
                g.precio_vta = double.Parse(dr["precio_vta"].ToString());
                g.es_propia = bool.Parse(dr["es_propia"].ToString());
                g.codigo_producto = int.Parse(dr["codigo_barras"].ToString());
                listGolosinas.Add(g);
            }
            dr.Close();
            cn.Close();


            return listGolosinas;
        }

     public static List<GolosinaQuery> ObtenerConFiltros(int? idMarca, bool? esPropia, int? idTipo, string nombre)
        {
            List<GolosinaQuery> listGolosinas = new List<GolosinaQuery>();
            GolosinaQuery g = null;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=LUCA\SQLSERVER;Initial Catalog=BD_Golosinas;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"Select g.id_golosina, g.nombre, g.descripcion, m.nombre as marca, g.stock, t.nombre as tipo_golosina, g.precio_vta, g.es_propia, g.codigo_barras
                                From Golosina g INNER JOIN Marca m ON g.id_marca = m.id_marca 
                                INNER JOIN Tipo_Golosina t ON g.id_tipo_golosina = t.id_tipo_golosina
                                WHERE 1=1";
            
            if(idMarca.HasValue && idMarca.Value != 0)
            {
                cmd.CommandText += " AND g.id_marca = @idMarca";
                cmd.Parameters.AddWithValue("@idMarca", idMarca.Value);
            }
            if(idTipo.HasValue && idTipo.Value != 0)
            {
                cmd.CommandText += " AND g.id_tipo_golosina = @IdTipoGolosina";
                cmd.Parameters.AddWithValue("@IdTipoGolosina", idTipo.Value);
            }
            if(esPropia.HasValue)
            {
                cmd.CommandText += " AND g.es_propia = @EsPropia";
                cmd.Parameters.AddWithValue("@EsPropia", esPropia);
            }
            if(nombre != string.Empty)
            {
                cmd.CommandText += " AND g.nombre like @nombreGol ";
                cmd.Parameters.AddWithValue("@nombreGol","%" + nombre + "%");
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                g = new GolosinaQuery();
                g.id_golosina = int.Parse(dr["id_golosina"].ToString());
                g.nombre = dr["nombre"].ToString();
                g.descripcion = dr["descripcion"].ToString();
                g.nombreMarca = dr["marca"].ToString();
                g.stock = int.Parse(dr["stock"].ToString());
                g.nombreTipoGolosina = dr["tipo_golosina"].ToString();
                g.precio_vta = double.Parse(dr["precio_vta"].ToString());
                g.es_propia = bool.Parse(dr["es_propia"].ToString());
                if (g.es_propia)
                    g.nombreEsPropia = "Si";
                else
                    g.nombreEsPropia = "No";
                g.codigo_producto = int.Parse(dr["codigo_barras"].ToString());
                listGolosinas.Add(g);
            }
            dr.Close();
            cn.Close();


            return listGolosinas;
        }

        public static List<GolosinaQuery> ObtenerPropias()
     {
         List<GolosinaQuery> listGolosinas = new List<GolosinaQuery>();
         GolosinaQuery g = null;
         SqlConnection cn = new SqlConnection();
         cn.ConnectionString = @"Data Source=LUCA\SQLSERVER;Initial Catalog=BD_Golosinas;Integrated Security=True";
         cn.Open();
         SqlCommand cmd = new SqlCommand();
         cmd.Connection = cn;
         cmd.CommandText = @"Select g.id_golosina, g.nombre, g.descripcion, m.nombre as marca, g.stock, t.nombre as tipo_golosina, g.precio_vta, g.es_propia, g.codigo_barras
                                From Golosina g INNER JOIN Marca m ON g.id_marca = m.id_marca 
                                INNER JOIN Tipo_Golosina t ON g.id_tipo_golosina = t.id_tipo_golosina
                                WHERE es_propia = 'True'";

        

             SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                g = new GolosinaQuery();
                g.id_golosina = int.Parse(dr["id_golosina"].ToString());
                g.nombre = dr["nombre"].ToString();
                g.descripcion = dr["descripcion"].ToString();
                g.nombreMarca = dr["marca"].ToString();
                g.stock = int.Parse(dr["stock"].ToString());
                g.nombreTipoGolosina = dr["tipo_golosina"].ToString();
                g.precio_vta = double.Parse(dr["precio_vta"].ToString());
                g.es_propia = bool.Parse(dr["es_propia"].ToString());
                if (g.es_propia)
                    g.nombreEsPropia = "Si";
                else
                    g.nombreEsPropia = "No";
                g.codigo_producto = int.Parse(dr["codigo_barras"].ToString());
                listGolosinas.Add(g);
            }
            dr.Close();
            cn.Close();


            return listGolosinas;
        }


        public static List<GolosinaQuery> ObtenerPorNombre(string nombre)
        {
            List<GolosinaQuery> listGolosinas = new List<GolosinaQuery>();
            GolosinaQuery g = null;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=LUCA\SQLSERVER;Initial Catalog=BD_Golosinas;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"Select g.id_golosina, g.nombre, g.descripcion, m.nombre as marca, g.stock, t.nombre as tipo_golosina, g.precio_vta, g.es_propia, g.codigo_barras
                                From Golosina g INNER JOIN Marca m ON g.id_marca = m.id_marca 
                                INNER JOIN Tipo_Golosina t ON g.id_tipo_golosina = t.id_tipo_golosina
                                WHERE es_propia = 'True'";

            if (nombre != string.Empty)
            {
                cmd.CommandText += " AND g.nombre like @nombreGol ";
                cmd.Parameters.AddWithValue("@nombreGol", "%" + nombre + "%");
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                g = new GolosinaQuery();
                g.id_golosina = int.Parse(dr["id_golosina"].ToString());
                g.nombre = dr["nombre"].ToString();
                g.descripcion = dr["descripcion"].ToString();
                g.nombreMarca = dr["marca"].ToString();
                g.stock = int.Parse(dr["stock"].ToString());
                g.nombreTipoGolosina = dr["tipo_golosina"].ToString();
                g.precio_vta = double.Parse(dr["precio_vta"].ToString());
                g.es_propia = bool.Parse(dr["es_propia"].ToString());
                if (g.es_propia)
                    g.nombreEsPropia = "Si";
                else
                    g.nombreEsPropia = "No";
                g.codigo_producto = int.Parse(dr["codigo_barras"].ToString());
                listGolosinas.Add(g);
            }
            dr.Close();
            cn.Close();


            return listGolosinas;

        }

        

     }



    }

