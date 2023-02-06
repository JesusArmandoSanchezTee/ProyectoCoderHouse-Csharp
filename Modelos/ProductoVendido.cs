using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreEntrega.Modelos
{
    public class ProductoVendido
    {

        public long id { get; set; }
        public int stock { get; set; }
        public long idProducto { get; set; }
        public long idVenta { get; set; }
    }
}
