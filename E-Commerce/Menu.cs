using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace E_Commerce
{
    public partial class Menu : Form
    {
        public string botonSeleccionado = "";
       
        public Menu()
        {
            InitializeComponent();
        }

        private void btPerfil_Click(object sender, EventArgs e)
        {
            //Oculto los otros paneles por si estan activos
            panelFiltros.Visible = false;

            //Pongo la barrita de seleccionado
            marcarElegido(btPerfil);

            //Mostrar o ocultar el panel
            panelPerfil.Visible = (panelPerfil.Visible == true) ? false : true;
        }
        private void btFiltros_Click(object sender, EventArgs e)
        {
            //Oculto los otros paneles por si estan activos
            panelPerfil.Visible = false;

            //Pongo la barrita de seleccionado
            marcarElegido(btFiltros);

            //Mostrar o ocultar el panel
            panelFiltros.Visible = (panelFiltros.Visible == true) ? false : true;
        }

        public void marcarElegido(Button botonElegido)
        {
            if (botonSeleccionado == botonElegido.Text)
            {
                panelSeleccionado.Visible = false;
                botonSeleccionado = "";
            }
            else 
            {
                botonSeleccionado = botonElegido.Text;
                panelSeleccionado.Height = botonElegido.Height;
                panelSeleccionado.Top = botonElegido.Top;
                panelSeleccionado.Visible = true;
            }

        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btFull_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            btFull.Visible = false;
            btFull.Enabled = false;
            btWindow.Visible = true;
            btWindow.Enabled = true;

        }

        private void btWindow_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            btFull.Visible = true;
            btFull.Enabled = true;
            btWindow.Visible = false;
            btWindow.Enabled = false;
        }

        private void btMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btIniciarSesion_Click(object sender, EventArgs e)
        {
            Login formLogin = new Login();
            this.Hide();
            formLogin.Show();
        }
    }
}
