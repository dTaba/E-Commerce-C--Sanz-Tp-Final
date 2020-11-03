using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce
{
    class dtoCliente
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string clave { get; set; }
        public string usuario { get; set; }
        public int puntos { get; set; }
        public string telefono { get; set; }
        public int nivel { get; set; }
        public int pedidosrealizados { get; set; }
        public string nacimiento { get; set; }
        public string direccion { get; set; }
    }
}
