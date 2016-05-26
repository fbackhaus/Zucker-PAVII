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
    public class GolosinaDao
    {
        public static void Insertar(Golosina gol)
        {
            //1. Abro la Conexion
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=ARMLGLOCCHIPI\SQLEXPRESS;Initial Catalog=BD_Golosinas;Integrated Security=True";
            cn.Open();
            //2.Creo el objeto command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"Insert into Golosina (id_golosina,
                                                    nombre,
                                                    descripcion,
                                                    id_marca,
                                                    stock,
                                                    id_tipo_golosina,
                                                    precio_vta,
                                                    es_propia,
                                                    codigo_barras) values (
                                                    @Id_Golosina,
                                                    @Nombre,
                                                    @Descripcion,
                                                    @Id_Marca,
                                                    @Stock,
                                                    @Id_Tipo_Golosina,
                                                    @Precio_Vta,
                                                    @Es_Propia,
                                                    @Codigo_Barras); select Scope_Identity() as ID";
            cmd.Parameters.AddWithValue("@Id_Golosina", gol.id_golosina);
            cmd.Parameters.AddWithValue("@Nombre", gol.nombre);
            cmd.Parameters.AddWithValue("@Descripcion", gol.descripcion);
            cmd.Parameters.AddWithValue("@Id_Marca", gol.id_marca);
            cmd.Parameters.AddWithValue("@Stock", gol.stock);
            cmd.Parameters.AddWithValue("@Id_Tipo_Golosina", gol.id_tipo_golosina);
            cmd.Parameters.AddWithValue("@Precio_Vta", gol.precio_vta);
            cmd.Parameters.AddWithValue("@Es_Propia", gol.es_propia);
            cmd.Parameters.AddWithValue("@Codigo_Barras", gol.codigo_producto);

            cmd.ExecuteNonQuery();

            cn.Close();
        }

        public static int ultimoID()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=LUCA\SQLSERVER;Initial Catalog=BD_Golosinas;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Select id_golosina from Golosina";
            int r = Convert.ToInt32(cmd.ExecuteScalar());
            cn.Close();
            return r;
        }
        public static void actualizarID(int id_gol)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=LUCA\SQLSERVER;Initial Catalog=BD_Golosinas;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Update ID_GOLOSINA set id = @id_gol";
            cmd.Parameters.AddWithValue("@id_gol", id_gol);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public static DataSet leerBD(string consulta)
        {
            
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=LUCA\SQLSERVER;Initial Catalog=BD_Golosinas;Integrated Security=True";
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

        public static void actualizar(Golosina gol)
        {
            //1. Abro la Conexion
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=LUCA\SQLSERVER;Initial Catalog=BD_Golosinas;Integrated Security=True";
            cn.Open();
            //2.Creo el objeto command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"update Golosina set nombre = @Nombre,
                                        descripcion = @Descripcion,
                                        id_marca = @Id_Marca,
                                        stock = @Stock,
                                        id_tipo_golosina = @Id_Tipo_Golosina,
                                        precio_vta = @Precio_Vta,
                                        es_propia = @Es_Propia,
                                        codigo_barras = @Codigo_Barras 
                                        where id_golosina = @Id_Golosina";
            cmd.Parameters.AddWithValue("@Id_Golosina", gol.id_golosina);
            cmd.Parameters.AddWithValue("@Nombre", gol.nombre);
            cmd.Parameters.AddWithValue("@Descripcion", gol.descripcion);
            cmd.Parameters.AddWithValue("@Id_Marca", gol.id_marca);
            cmd.Parameters.AddWithValue("@Stock", gol.stock);
            cmd.Parameters.AddWithValue("@Id_Tipo_Golosina", gol.id_tipo_golosina);
            cmd.Parameters.AddWithValue("@Precio_Vta", gol.precio_vta);
            cmd.Parameters.AddWithValue("@Es_Propia", gol.es_propia);
            cmd.Parameters.AddWithValue("@Codigo_Barras", gol.codigo_producto);

            cmd.ExecuteNonQuery();

            cn.Close();
        }

//        public List<Golosina> obtenerTodos()
//        {
//            List<Golosina> listaGolosinas = new List<Golosina>();
//            SqlConnection cn= new SqlConnection();
//            cn.Open();
//            SqlCommand cmd = new SqlCommand();
//            cmd.Connection = cn;
//            cmd.CommandText = @"Select g.id_golosina, g.nombre, g.descripcion, marca.nombre as marca, g.stock, tipo_golosina.nombre as tipo_golosina, g.precio_vta, g.es_propia, g.codigo_barras
//                                From Golosina g INNER JOIN Marca m ON g.id_marca = m.id_marca 
//                                INNER JOIN Tipo_Golosina t ON g.id_tipo_golosina = t.id_tipo_golosina";
//            SqlDataReader dr = cmd.ExecuteReader();
//            while(dr.Read())
//            {
           /*     Golosina gol = new Golosina()
                {
                    id_golosina = int.Parse(dr["id_golosina"].ToString()),
                    nombre = dr["nombre"].ToString(),
                    descripcion = dr["descripcion"].ToString(),

                    
                };
                */
            }
        }
    

