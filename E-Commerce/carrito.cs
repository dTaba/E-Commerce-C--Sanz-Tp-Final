using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace E_Commerce
{
    public partial class carrito : Form
    {
        public List<dtoArticulo> articulos;
        public Form formmenu;
        public int total;
        public carrito(List<dtoArticulo> lista, Form formPrincipal)
        {
            InitializeComponent();
            articulos = lista;
            formmenu = formPrincipal;
        }
        
        public int valor = 0;
        private void carrito_Load(object sender, EventArgs e)
        {
            actualizarArticulo();
            calcularTotal();
        }

        private void btDerecha_Click(object sender, EventArgs e)
        {
            if(valor == articulos.Count -1)
            {
                MessageBox.Show("No hay nada mas en el carrito", "Error");
            }
            else
            {
                valor++;
                actualizarArticulo();
            }

        }

        private void actualizarArticulo()
        {
            lblPrecio1.Text = "$ " + articulos[valor].precio;
            lblProducto1.Text = articulos[valor].nombre;

            img1.BackgroundImageLayout = ImageLayout.Zoom;
            img12.BackgroundImageLayout = ImageLayout.Zoom;
            img13.BackgroundImageLayout = ImageLayout.Zoom;

            img1.BackgroundImage = articulos[valor].img1;
            img12.BackgroundImage = articulos[valor].img2;
            img13.BackgroundImage = articulos[valor].img3;
        }

        private void btIzquierda_Click(object sender, EventArgs e)
        {
            if (valor == 0)
            {
                MessageBox.Show("No hay nada mas en el carrito", "Error");
            }
            else
            {
                valor--;
                actualizarArticulo();
            }
        }

        private void calcularTotal()
        {
            int suma = 0;
            
            for (int i = 0; i <= articulos.Count - 1; i++)
            {
                suma += Convert.ToInt32(articulos[i].precio);    
            }

            lblTotal.Text = "Total: $" + suma;
        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            formmenu.Show();
            this.Close();
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            articulos.RemoveAt(valor);
            valor = 0;

            if(articulos.Count >= 1)
            {
                MessageBox.Show("Articulo eliminado con exito", "Exito");
                
                actualizarArticulo();
                calcularTotal();
            }
            else
            {
                MessageBox.Show("No hay mas articulos en el carrito, volviendo a menu principal", "Exito");
                formmenu.Show();
                this.Close();
            }
        }

        private void btComprar_Click(object sender, EventArgs e)
        {
            daoCliente.nuevaCompra(articulos);
            daoCliente.actualizarDatos();
            MessageBox.Show("Compra realizada con exito", "Exito");
        }
    }
}
