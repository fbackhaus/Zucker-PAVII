using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace Dao
{
    public class LoteProduccionDao
    {

        public static void Insertar(LoteProduccion lote, List<DetalleProduccion> listaDetalles)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=FEDE-PC;Initial Catalog=BD_Golosinas;Integrated Security=True";
            cn.Open();
            SqlTransaction tran = cn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"Insert into Produccion (id_produccion,fecha_y_hora, id_empleado) 
                                   values(@Id_produccion, @Fecha, @Id_emp)";
                cmd.Parameters.AddWithValue(@"Id_produccion", lote.codLote);
                cmd.Parameters.AddWithValue(@"Fecha", lote.fecha);
                cmd.Parameters.AddWithValue(@"Id_emp", lote.id_empleado);
                cmd.Transaction = tran;

                cmd.ExecuteNonQuery();

                foreach (DetalleProduccion detalle in listaDetalles)
                {
                    detalle.id_produccion= lote.codLote;
                    SqlCommand cmdDet = new SqlCommand();
                    cmdDet.Connection = cn;
                    cmdDet.CommandText = @"Insert into Detalle_Produccion (id_produccion, id_golosina,cantidad)
                                                values (@id_prod,@Id_Gol,@Cant)";
                    cmdDet.Parameters.AddWithValue(@"id_prod",detalle.id_produccion);
                    cmdDet.Parameters.AddWithValue(@"Id_Gol",detalle.id_golosina);
                    cmdDet.Parameters.AddWithValue(@"Cant",detalle.cantidad);
                    
                    cmdDet.Transaction = tran;

                    cmdDet.ExecuteNonQuery();
                    
                    ActualizarStock(detalle);

                }
                tran.Commit();
                 }
           
            catch(SqlException ex)
            {
                tran.Rollback();

                throw new ApplicationException("Error al Guardar el Pedido: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }

            
        }

        public static DetalleProduccion obtenerPorID(int id_gol)
        {
            DetalleProduccion detalle = null;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=FEDE-PC;Initial Catalog=BD_Golosinas;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT     Detalle_Produccion.id_golosina,Detalle_Produccion.id_detalle ,Detalle_Produccion.id_produccion, Golosina.nombre, Golosina.stock
                                FROM         Detalle_Produccion INNER JOIN
                                Golosina ON Detalle_Produccion.id_golosina = Golosina.id_golosina
                                WHERE Detalle_Produccion.id_golosina = @id_gol";

            cmd.Parameters.AddWithValue("@id_gol", id_gol);


            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                detalle = new DetalleProduccion();
                detalle.id_golosina = int.Parse(dr["id_golosina"].ToString());
                detalle.id_produccion = int.Parse(dr["id_produccion"].ToString());
                detalle.id_detalle = int.Parse(dr["id_detalle"].ToString());
                detalle.nombreGol = dr["nombre"].ToString();
                detalle.stock = int.Parse(dr["stock"].ToString());
            }
            dr.Close();
            cn.Close();



            return detalle;
        }

        public static int ultimoIDLote()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=FEDE-PC;Initial Catalog=BD_Golosinas;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Select MAX(id_produccion) from Produccion";
            int r = Convert.ToInt32(cmd.ExecuteScalar());
            cn.Close();
            return r;
        }

        public static int ultimoIDDetalle()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=FEDE-PC;Initial Catalog=BD_Golosinas;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Select MAX(id_detalle) FROM Detalle_Produccion";
            int r = Convert.ToInt32(cmd.ExecuteScalar());
            cn.Close();
            return r;
        }


        public static void ActualizarStock(DetalleProduccion detalle)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=FEDE-PC;Initial Catalog=BD_Golosinas;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Update Golosina set stock = @Stock Where id_golosina = @Id_gol";
            cmd.Parameters.AddWithValue("@Stock", detalle.stock);
            cmd.Parameters.AddWithValue("@Id_gol", detalle.id_golosina);
            cmd.ExecuteNonQuery();
            cn.Close();
        }



       

    }
}
