using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreEntrega.Modelos
{
    public class Producto
    {
        public long id { get; set; }
        public string descripcion { get; set; }
        public decimal costo { get; set; }
        public decimal precioVenta { get; set; }
        public int stock { get; set; }
        public long idUsuario { get; set; } 
    }
}
