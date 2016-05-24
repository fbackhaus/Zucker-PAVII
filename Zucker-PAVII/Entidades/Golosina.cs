using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Golosina
    {
        public int? id_golosina { get; set; }
        public int id_marca { get; set; }
        public int id_tipo_golosina { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int? stock { get; set; }
        public float precio_vta { get; set; }
        public bool es_propia { get; set; }
        public int codigo_producto { get; set; }

        public Golosina(int? id_golosina, int id_marca, int id_tipo_golosina, int? stock, float precio_vta, bool es_propia, int codigo_producto)
        {
            this.id_golosina = id_golosina;
            this.id_marca = id_marca;
            this.id_tipo_golosina = id_tipo_golosina;
            if (stock < 0)
                this.stock = 0;
            else
                this.stock = stock;
            this.precio_vta = precio_vta;
            this.es_propia = es_propia;
            this.codigo_producto = codigo_producto;

        }

        public Golosina()
        {
            // TODO: Complete member initialization
        }

    }
}
