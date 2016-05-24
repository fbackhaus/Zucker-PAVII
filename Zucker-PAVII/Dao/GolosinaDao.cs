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
            cn.ConnectionString = "Data Source=FEDE-PC;Initial Catalog=BD_Golosinas;Integrated Security=True";
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
            cn.ConnectionString="Data Source=FEDE-PC;Initial Catalog=BD_Golosinas;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Select id from ID_GOLOSINA";
            int r = Convert.ToInt32(cmd.ExecuteScalar());
            cn.Close();
            return r;
        }
        public static void actualizarID(int id_gol)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=FEDE-PC;Initial Catalog=BD_Golosinas;Integrated Security=True";
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
            cn.ConnectionString = "Data Source=FEDE-PC;Initial Catalog=BD_Golosinas;Integrated Security=True";
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

    }
}
