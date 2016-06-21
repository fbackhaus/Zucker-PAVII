using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CompraAProveedor
    {
        public int id_compra { get; set; }
        public int id_empleado { get; set; }
        public DateTime fecha_compra { get; set; }
        public double monto_total { get; set; }
        public string nombre_empleado { get; set; }
    }
}
