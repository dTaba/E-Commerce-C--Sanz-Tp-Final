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
        public Form menu;
        public editarPerfil(Form form)
        {
            InitializeComponent();
            menu = form;
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
            txNombre.Text = Helper.usuarioLogeado.nombre;
            txPedidos.Text = Helper.usuarioLogeado.pedidosrealizados.ToString();
            txClave.Text = Helper.usuarioLogeado.clave;
            txCorreo.Text = Helper.usuarioLogeado.email;
        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            menu.Show();
            this.Hide();
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            if (txDireccion.Text != "" && txTelefono.Text != "" && txCorreo.Text != "" && txClave.Text != "")
            {
                daoCliente.actualizarCliente(txDireccion.Text, txTelefono.Text, txCorreo.Text, txClave.Text);
                MessageBox.Show("Datos actualizados correctamente", "Exito");
            }
            else
            {
                MessageBox.Show("Uno de los campos esta vacio", "Error");
            }

        }
    }
}
