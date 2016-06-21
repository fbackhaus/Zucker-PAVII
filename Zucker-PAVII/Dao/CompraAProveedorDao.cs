using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Dao
{
    public class CompraAProveedorDao
    {
        public static List<String> cargarComboProveedores()
        {
            List<String> listaProveedores = new List<String>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=FEDE-PC;Initial Catalog=BD_Golosinas;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Select razon_social from Proveedor";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                listaProveedores.Add(dr["razon_social"].ToString());
            }
            dr.Close();
            cn.Close();
            return listaProveedores;
        }

        public static List<DetalleCompraAProveedor> obtenerConFiltros(int? id_proveedor, string nombreMP)
        {
            List<DetalleCompraAProveedor> listaDetalles = new List<DetalleCompraAProveedor>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=FEDE-PC;Initial Catalog=BD_Golosinas;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"Select p.id_proveedor, p.razon_social, p.cuit, mp.id_materia_prima, mp.nombre, mp.codigo, mp.stock, mpp.precio, mp.descripcion
                                FROM Proveedor p INNER JOIN MP_X_Proveedor mpp ON p.id_proveedor = mpp.id_proveedor
                                INNER JOIN Materia_Prima mp ON mpp.id_materia_prima = mp.id_materia_prima
                                WHERE 1 = 1 ";
            if (id_proveedor.HasValue && id_proveedor != 0)
            {
                cmd.CommandText += "AND p.id_proveedor = @id_prov ";
                cmd.Parameters.AddWithValue("@id_prov", id_proveedor.Value);
            }

            if (nombreMP != string.Empty)
            {
                cmd.CommandText += "AND mp.nombre like @nombreMP ";
                cmd.Parameters.AddWithValue("@nombreMP","%" + nombreMP + "%");
            }

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DetalleCompraAProveedor detalle = new DetalleCompraAProveedor();
                detalle.codigo_mp = int.Parse(dr["codigo"].ToString());
                detalle.descripcion = dr["descripcion"].ToString();
                detalle.id_materia_prima = int.Parse(dr["id_materia_prima"].ToString());
                detalle.id_proveedor = int.Parse(dr["id_proveedor"].ToString());
                detalle.monto_unitario = double.Parse(dr["precio"].ToString());
                detalle.nombre_proveedor = dr["razon_social"].ToString();
                detalle.cuit = int.Parse(dr["cuit"].ToString());
                detalle.nombre_materia_prima = dr["nombre"].ToString();
                detalle.stock = int.Parse(dr["stock"].ToString());

                listaDetalles.Add(detalle);
            }
            dr.Close();
            cn.Close();



            return listaDetalles;
        }

        public static DetalleCompraAProveedor obtenerPorID(int id_mp)
        {
            DetalleCompraAProveedor detalle = null;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=FEDE-PC;Initial Catalog=BD_Golosinas;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"Select p.id_proveedor, p.razon_social, p.cuit, mp.id_materia_prima, mp.nombre, mp.codigo, mp.stock, mpp.precio, mp.descripcion
                                FROM Proveedor p INNER JOIN MP_X_Proveedor mpp ON p.id_proveedor = mpp.id_proveedor
                                INNER JOIN Materia_Prima mp ON mpp.id_materia_prima = mp.id_materia_prima
                                WHERE mp.id_materia_prima = @id_mp ";

            cmd.Parameters.AddWithValue("@id_mp", id_mp);


            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                detalle = new DetalleCompraAProveedor();
                detalle.codigo_mp = int.Parse(dr["codigo"].ToString());
                detalle.descripcion = dr["descripcion"].ToString();
                detalle.id_materia_prima = int.Parse(dr["id_materia_prima"].ToString());
                detalle.id_proveedor = int.Parse(dr["id_proveedor"].ToString());
                detalle.monto_unitario = double.Parse(dr["precio"].ToString());
                detalle.nombre_proveedor = dr["razon_social"].ToString();
                detalle.cuit = int.Parse(dr["cuit"].ToString());
                detalle.nombre_materia_prima = dr["nombre"].ToString();
                detalle.stock = int.Parse(dr["stock"].ToString());

            }
            dr.Close();
            cn.Close();



            return detalle;
        }
        public static int ultimoIDCompra()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=FEDE-PC;Initial Catalog=BD_Golosinas;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Select id from ID_COMPRA_A_PROV";
            int r = Convert.ToInt32(cmd.ExecuteScalar());
            cn.Close();
            return r;
        }
        public static void actualizarIDCompra(int id_com)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=FEDE-PC;Initial Catalog=BD_Golosinas;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Update ID_COMPRA_A_PROV set id = @id_compra";
            cmd.Parameters.AddWithValue("@id_compra", id_com);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public static int ultimoIDDetalle()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=FEDE-PC;Initial Catalog=BD_Golosinas;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Select id from ID_DETALLE_COMPRA_A_PROV";
            int r = Convert.ToInt32(cmd.ExecuteScalar());
            cn.Close();
            return r;
        }
        public static void actualizarIDDetalle(int id_detalle)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=FEDE-PC;Initial Catalog=BD_Golosinas;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Update ID_DETALLE_COMPRA_A_PROV set id = @id_detalle";
            cmd.Parameters.AddWithValue("@id_detalle", id_detalle);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public static void Insertar(CompraAProveedor compra, List<DetalleCompraAProveedor> listaDetalles)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=FEDE-PC;Initial Catalog=BD_Golosinas;Integrated Security=True";
            cn.Open();
            SqlTransaction tran = cn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"Insert into Compra_A_Proveedor (id_compra, id_empleado, fecha_compra, monto_total) values (
                                    @id_compra, @id_empleado, @fecha_compra, @monto_total)";
                cmd.Parameters.AddWithValue("@id_compra", compra.id_compra);
                cmd.Parameters.AddWithValue("@id_empleado", compra.id_empleado);
                cmd.Parameters.AddWithValue("@fecha_compra", compra.fecha_compra);
                cmd.Parameters.AddWithValue("@monto_total", compra.monto_total);
                cmd.Transaction = tran;

                cmd.ExecuteNonQuery();
                foreach(DetalleCompraAProveedor detalle in listaDetalles)
                {

                    detalle.id_detalle = ultimoIDDetalle() + 1;
                    detalle.id_compra = compra.id_compra;
                    SqlCommand cmdDet = new SqlCommand();
                    cmdDet.Connection = cn;
                    cmdDet.CommandText = @"Insert into Detalle_Compra_A_Prov (id_detalle_compra_prov, id_compra, id_materia_prima
                                            , cantidad, monto_unitario, id_proveedor) values ( @Id_Detalle_Compra_Prov, @Id_Compra
                                            , @Id_Materia_Prima, @Cantidad, @Monto_Unitario, @Id_Proveedor)";
                    cmdDet.Parameters.AddWithValue("@Id_Detalle_Compra_Prov", detalle.id_detalle);
                    cmdDet.Parameters.AddWithValue("@Id_Compra", detalle.id_compra);
                    cmdDet.Parameters.AddWithValue("@Id_Materia_Prima", detalle.id_materia_prima);
                    cmdDet.Parameters.AddWithValue("@Cantidad", detalle.cantidad);
                    cmdDet.Parameters.AddWithValue("@Monto_Unitario", detalle.monto_unitario);
                    cmdDet.Parameters.AddWithValue("@Id_Proveedor", detalle.id_proveedor);
                    cmdDet.Transaction = tran;

                    cmdDet.ExecuteNonQuery();
                    actualizarIDDetalle(detalle.id_detalle);
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

        public static void ActualizarStock(DetalleCompraAProveedor detalle)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=FEDE-PC;Initial Catalog=BD_Golosinas;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Update Materia_Prima set stock = @Stock Where id_materia_prima = @Id_Materia_Prima";
            cmd.Parameters.AddWithValue("@Stock", detalle.stock);
            cmd.Parameters.AddWithValue("@Id_Materia_Prima", detalle.id_materia_prima);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

    }
}
