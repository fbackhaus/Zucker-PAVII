using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        
	/*[id_cliente] [int] NOT NULL,
	[cuit] [bigint] NOT NULL,
	[razon_social] [varchar](50) NOT NULL,
	[fecha_fundacion] [datetime] NOT NULL,
	[email] [varchar](50) NOT NULL,
	[telefono] [int] NOT NULL,
	[calle] [varchar](50) NOT NULL,
	[numero] [int] NOT NULL,
	[piso] [int] NULL,
	[dpto] [int] NULL,
	[id_localidad] [int] NOT NULL,
	[codigo_postal] [int] NOT NULL,
	[nro_cuenta] [int] NOT NULL,
	[es_primera_vez] [bit] NOT NULL */
        public int id_cliente { get; set; }
        public string cuit { get; set; }
        public string razon_social { get; set; } 
        public DateTime fecha_fundacion { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string calle { get; set; }
        public int numero { get; set; }
        public int? piso { get; set; }
        public string  dpto { get; set; }
        public int id_localidad { get; set; }
        public int codigo_postal { get; set; }
        public double nro_cuenta { get; set; }
        public bool es_primera_vez { get; set; }

        public Cliente()
        {

        }

        public Cliente(int id_cliente, string cuit, string razon_social, DateTime fecha_fundacion, string email,
                       string telefono, string calle, int numero, int? piso, string dpto, int id_localidad, int codigo_postal,
                       double nro_cuenta, bool es_primera_vez)
        {
            this.id_cliente = id_cliente;
            this.cuit = cuit;
            this.razon_social = razon_social;
            this.fecha_fundacion = fecha_fundacion;
            this.email = email;
            this.telefono = telefono;
            this.calle = calle;
            this.numero = numero;
            
            this.piso = piso;
            this.dpto = dpto;
            this.id_localidad = id_localidad;
            this.codigo_postal = codigo_postal;
            this.nro_cuenta = nro_cuenta;
            this.es_primera_vez = es_primera_vez;
        }


    }
}
