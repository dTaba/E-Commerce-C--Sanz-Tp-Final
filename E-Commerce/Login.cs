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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btRegistrarse_Click(object sender, EventArgs e)
        {
            Registro formRegistro = new Registro();
            this.Hide();
            formRegistro.Show();
        }

        public void borrarTexto(object sender, EventArgs e)
        {
            TextBox textElegido = (TextBox)sender;
            textElegido.Text = string.Empty;
        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            Menu formMenu = new Menu();
            this.Hide();
            formMenu.Show();
        }
    }
}
