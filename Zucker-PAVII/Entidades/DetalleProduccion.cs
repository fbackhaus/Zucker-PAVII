using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleProduccion
    {
        public int id_produccion { get; set; }
        public int id_detalle { get; set; }
        public int id_golosina { get; set; }
        public int cantidad { get; set; }
        public string nombreGol { get; set; }
        public int stock { get; set; }

    }
}
