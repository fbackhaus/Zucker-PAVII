using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleCompraAProveedor
    {
        public int id_materia_prima { get; set; }
        public int id_compra { get; set; }
        public int id_detalle { get; set; }
        public int cantidad { get; set; }
        public double monto_unitario { get; set; }
        public string nombre_proveedor { get; set; }
        public int id_proveedor { get; set; }
        public string descripcion { get; set; }
        public int codigo_mp { get; set; }
        public int stock { get; set; }
        public int cuit { get; set; }
        public string nombre_materia_prima { get; set; }
    }
}
