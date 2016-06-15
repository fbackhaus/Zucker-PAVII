using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empleado
    {

        public int? id_empleado { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime fechaNacimiento{ get; set; }
        public int dni { get; set; }
        public int id_cargo{ get; set; }
        public int num_cuenta { get; set; }
        public bool puede_realizar_pedidos { get; set; }
      

         public Empleado(int? id_empleado, string nombre, string apellido, DateTime fechaNacimiento, int dni, bool puede_realizar_pedidos)
        {
            this.id_empleado = id_empleado;
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaNacimiento= fechaNacimiento;
            this.dni = dni;
            this.puede_realizar_pedidos = puede_realizar_pedidos;
        }

         public Empleado() { }


    }
}
