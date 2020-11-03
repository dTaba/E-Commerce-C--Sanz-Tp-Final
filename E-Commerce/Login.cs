using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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

        public void pagAnterior()
        {
            Menu formMenu = new Menu();
            this.Hide();
            formMenu.Show();
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
            pagAnterior();
        }

        private void btIniciarSesion_Click(object sender, EventArgs e)
        {
            if (txUsuario.Text != "" & txClave.Text !="" & txCorreo.Text !="")
            {
                if(daoCliente.logearUsuario(txUsuario.Text, txClave.Text, txCorreo.Text))
                {
                    MessageBox.Show("Logeado correctamente");
                    Menu formMenu = new Menu();
                    formMenu.btIniciarSesion.Visible = false;
                    this.Hide();
                    formMenu.Show();
                }
                else 
                {
                    MessageBox.Show("Datos Incorrectos");
                }


            }
        }
    }
}
