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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void btPerfil_Click(object sender, EventArgs e)
        {
            panelSeleccionado.Height = btPerfil.Height;
            panelSeleccionado.Top = btPerfil.Top;
            panelSeleccionado.Visible = true;

            panelPerfil.Visible = (panelPerfil.Visible == true) ? false : true;
        }

        private void btAjustes_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelSeleccionado.Height = btFiltros.Height;
            panelSeleccionado.Top = btFiltros.Top;
            panelSeleccionado.Visible = true;
            panelPerfil.Visible = false;

            //panelPerfil.Visible = (panelPerfil.Visible == true) ? false : true;
        }
    }
}
