using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class EmpleadoQuery : Empleado
    {
        public string nombreCargo { get; set; }
        public string numeroDNI { get; set; }
        public string nombrePedido { get; set; }

    }
}
