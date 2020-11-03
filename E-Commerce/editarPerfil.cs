using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Commerce
{
    public partial class editarPerfil : Form
    {
        public editarPerfil()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void editarPerfil_Activated(object sender, EventArgs e)
        {
            txNombre.Text = Helper.usuarioLogeado.nombre;
            txApellido.Text = Helper.usuarioLogeado.apellido;
            txDireccion.Text = Helper.usuarioLogeado.direccion;
            txTelefono.Text = Helper.usuarioLogeado.telefono;
            txFecha.Text = Helper.usuarioLogeado.nacimiento;
            txUsuario.Text = Helper.usuarioLogeado.usuario;
            txNivel.Text = Helper.usuarioLogeado.nivel.ToString();
            txNombre.Text = Helper.usuarioLogeado.nombre;
            txPedidos.Text = Helper.usuarioLogeado.pedidosrealizados.ToString();
            txClave.Text = Helper.usuarioLogeado.clave;
            txCorreo.Text = Helper.usuarioLogeado.email;
            txPuntos.Text = Helper.usuarioLogeado.puntos.ToString();
        }

        private void editarPerfil_Load(object sender, EventArgs e)
        {

        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            Menu form = new Menu();
            form.Show();
            this.Hide();
        }
    }
}
