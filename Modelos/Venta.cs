using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreEntrega.Modelos
{
    public class Venta
    {
        public long id { get; set; }
        public string comentario { get; set; }
        public long idUsuario { get; set; }
    }
}
