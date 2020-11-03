using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;
using System.IO;

namespace E_Commerce
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        public void paginaAnterior()
        {
            Login formLogin = new Login();
            this.Hide();
            formLogin.Show();
        }

        public void borrarTexto(object sender, EventArgs e)
        {
            TextBox textElegido = (TextBox)sender;
            textElegido.Text = string.Empty;
        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            paginaAnterior();
        }

        private void btRegistrarse_Click(object sender, EventArgs e)
        {
            if (!IsValid(txCorreo.Text))
            {
                MessageBox.Show("El email no es valido", "Campo incorrecto");
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(Helper.connectionString);
                    con.Open();

                    SqlCommand cmdUsuario = new SqlCommand("Select id from Clientes where usuario = '" + txUsuario.Text + "'", con);
                    var resultUsuario = cmdUsuario.ExecuteScalar();

                    if (resultUsuario != null)
                    {
                        MessageBox.Show(string.Format("El usuario {0} ya esta en uso", this.txUsuario.Text));
                        con.Close();
                    }
                    else
                    {
                        SqlCommand cmdMail = new SqlCommand("Select id from Clientes where mail = '" + txCorreo.Text + "'", con);
                        var resultMail = cmdMail.ExecuteScalar();

                        if (resultMail != null)
                        {
                            MessageBox.Show(string.Format("El mail {0} ya esta en uso", this.txCorreo.Text));
                            con.Close();
                        }
                        else
                        {
                            string fecha = txDia.Text + "/" + txMes.Text + "/" + txAño.Text;
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                cmd.Connection = con;
                                cmd.CommandText = @"INSERT INTO Clientes (id, usuario, clave, mail, nombre, nacimiento, cantPedidos, nivel, puntos, apellido, direccion, telefono) 
                                                VALUES ([id],'[usuario]','[clave]','[mail]','[nombre]','[nacimiento]', [cantPedidos], [nivel], [puntos], '[apellido]', '[direccion]', '[telefono]')";

                                int id = Helper.GetNextId("Clientes");

                                cmd.CommandText = cmd.CommandText.Replace("[id]", id.ToString());
                                cmd.CommandText = cmd.CommandText.Replace("[usuario]", txUsuario.Text);
                                cmd.CommandText = cmd.CommandText.Replace("[clave]", txClave.Text);
                                cmd.CommandText = cmd.CommandText.Replace("[mail]", txCorreo.Text);
                                cmd.CommandText = cmd.CommandText.Replace("[nombre]", txNombre.Text);
                                cmd.CommandText = cmd.CommandText.Replace("[nacimiento]", fecha);
                                cmd.CommandText = cmd.CommandText.Replace("[cantPedidos]", "0");
                                cmd.CommandText = cmd.CommandText.Replace("[nivel]", "0");
                                cmd.CommandText = cmd.CommandText.Replace("[puntos]", "0");
                                cmd.CommandText = cmd.CommandText.Replace("[apellido]", txApellido.Text);
                                cmd.CommandText = cmd.CommandText.Replace("[direccion]", txDireccion.Text);
                                cmd.CommandText = cmd.CommandText.Replace("[telefono]", txTelefono.Text);

                                cmd.ExecuteNonQuery();
                                con.Close();

                                MessageBox.Show("Usuario registrado correctamente, proceda a logearse");
                                paginaAnterior();
                            }
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public bool IsValid(string emailaddress)
        {
            if (txUsuario.Text != "" & txNombre.Text != "" & txApellido.Text != "" & txCorreo.Text != "" & txClave.Text != "" & txDia.Text != "")
            {
                try
                {
                    MailAddress m = new MailAddress(emailaddress);

                    return true;
                }
                catch (FormatException)
                {
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Hay campos vacios");
                return false;
            }
        }

        private void txNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
        }

        private void txApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
        }

        private void txTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }
    }
}
