using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce
{
    public class dtoArticulo
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public Image img1 { get; set; }
        public Image img2 { get; set; }
        public Image img3 { get; set; }
        public decimal vendidos { get; set; }
        public decimal stock { get; set; }
        public string categoria { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
    }
}
