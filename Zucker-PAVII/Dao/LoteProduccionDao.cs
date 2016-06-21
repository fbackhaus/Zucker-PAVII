using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace Dao
{
    class LoteProduccionDao
    {

        public static void Insertar(LoteProduccion lp)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=FEDE-PC;Initial Catalog=BD_Golosinas;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "INSERT into PRODUCCION (id_produccion,fecha_y_hora,id_empleado) values @Id_produccion, @Fecha,@Empleado ";
            cmd.Parameters.AddWithValue(@"Id_produccion", lp.codLote);
            cmd.Parameters.AddWithValue(@"Fecha", lp.fecha);
            cmd.Parameters.AddWithValue(@"Empleado", lp.id_empleado);

            cmd.ExecuteNonQuery();

            cn.Close();                        
            
        }

    }
}
