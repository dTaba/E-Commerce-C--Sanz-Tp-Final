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

namespace E_Commerce
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }
        internal static string conn = @"server=LAPTOP-LHBBVFT9\SQLEXPRESS;Database=ArticulosECommerce;Trusted_Connection=True";
        SqlConnection con = new SqlConnection(conn);
        public void borrarTexto(object sender, EventArgs e)
        {
            TextBox textElegido = (TextBox)sender;
            textElegido.Text = string.Empty;
        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            Login formLogin = new Login();
            this.Hide();
            formLogin.Show();
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
                    con.Open();
                    SqlCommand cmd2 = new SqlCommand("Select id from Clientes where usuario = '" + txUsuario.Text + "'", con);
                    cmd2.Parameters.AddWithValue("usuario", this.txUsuario.Text);
                    var result = cmd2.ExecuteScalar();
                    if (result != null)
                    {
                        MessageBox.Show(string.Format("El usuario {0} ya esta en uso", this.txUsuario.Text));
                        con.Close();
                    }
                    else
                    {
                        SqlCommand cmd3 = new SqlCommand("Select id from Clientes where mail = '" + txCorreo.Text + "'", con);
                        cmd3.Parameters.AddWithValue("mail", this.txCorreo.Text);
                        var result2 = cmd3.ExecuteScalar();
                        if (result2 != null)
                        {
                            MessageBox.Show(string.Format("El mail {0} ya esta en uso", this.txCorreo.Text));
                            con.Close();
                        }
                        else
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                cmd.Connection = con;
                                cmd.CommandText = @"INSERT INTO Clientes (id, usuario, clave, mail, nombre, nacimiento, cantPedidos, nivel, puntos) 
                                                VALUES ([id],'[usuario]','[clave]','[mail]','[nombre]','[nacimiento]', [cantPedidos], [nivel], [puntos])";

                                int id = Helper.GetNextId("Clientes");

                                cmd.CommandText = cmd.CommandText.Replace("[id]", id.ToString());
                                cmd.CommandText = cmd.CommandText.Replace("[usuario]", txUsuario.Text);
                                cmd.CommandText = cmd.CommandText.Replace("[clave]", txClave.Text);
                                cmd.CommandText = cmd.CommandText.Replace("[mail]", txCorreo.Text);
                                cmd.CommandText = cmd.CommandText.Replace("[nombre]", txNombre.Text);
                                cmd.CommandText = cmd.CommandText.Replace("[nacimiento]", txNacimiento.Text);
                                cmd.CommandText = cmd.CommandText.Replace("[cantPedidos]", "0");
                                cmd.CommandText = cmd.CommandText.Replace("[nivel]", "0");
                                cmd.CommandText = cmd.CommandText.Replace("[puntos]", "0");

                                cmd.ExecuteNonQuery();
                                con.Close();
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

        private void txNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
