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
        public int valor = 0;
        List<dtoArticulo> lista = new List<dtoArticulo>();
        List<Panel> listaPicture = new List<Panel>();
        List<Panel> listaPicture2 = new List<Panel>();
        List<Panel> listaPicture3 = new List<Panel>();
        List<Label> listaPrecios = new List<Label>();
        List<Label> listaNombres = new List<Label>();
        List<Label> listaDesc = new List<Label>();
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

        private void Menu_Shown(object sender, EventArgs e)
        {
            if (Helper.usuarioLogeado != null)
            {
                lblUsuario.Text = Helper.usuarioLogeado.usuario;
                lblUsuario.Visible = true;
                lblBienvenido.Visible = true;
                btIniciarSesion.Visible = false;
            }
        }

        private void btCerrarSesion_Click(object sender, EventArgs e)
        {
            if (Helper.usuarioLogeado != null)
            {
                DialogResult dr = MessageBox.Show("Esta seguro que quiere cerrar sesión?", "LOGOUT", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    Helper.usuarioLogeado = null;
                    lblUsuario.Visible = false;
                    lblBienvenido.Visible = false;
                    btIniciarSesion.Visible = true;
                }

            }
            else
            {
                MessageBox.Show("No estas logeado maquinola", "LOGOUT");
            }
        }

        private void btEditarPerfil_Click(object sender, EventArgs e)
        {
            if (Helper.usuarioLogeado != null)
            {
                editarPerfil editar = new editarPerfil();
                editar.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usted no esta logeado", "Error");
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            lista = daoArticulo.cargarImagenesDestacadas();

            listaPicture = new List<Panel> { img1, img2, img3, img4 };
            listaPicture2 = new List<Panel> { img12, img22, img32, img42 };
            listaPicture3 = new List<Panel> { img13, img23, img33, img43 };

            listaPrecios = new List<Label> { lblPrecio1, lblPrecio2, lblPrecio3, lblPrecio4 };
            listaNombres = new List<Label> { lblProducto1, lblProducto2, lblProducto3, lblProducto4 };
            listaDesc = new List<Label> { lblDesc1, lblDesc2, lblDesc3, lblDesc4 };


            for (int i = 0; i < 4; i++)
            {
                listaPicture[i].BackgroundImageLayout = ImageLayout.Zoom;
                listaPicture[i].BackgroundImage = lista[i].img1;
                listaPicture2[i].BackgroundImage = lista[i].img2;
                listaPicture3[i].BackgroundImage = lista[i].img3;

                listaPrecios[i].Text = "$ " + lista[i].precio.ToString();
                listaNombres[i].Text = lista[i].nombre;
                listaDesc[i].Text = lista[i].descripcion;
            }
        }

        private void lblDesc1_Click(object sender, EventArgs e)
        {

        }

        private void btDerecha_Click(object sender, EventArgs e)
        {


            if (valor == lista.Count - 4)
            {
                MessageBox.Show("No hay mas articulos para mostrar", "Error");
            }
            else
            {
                valor++;
                for (int i = 0; i < 4; i++)
                {
                    listaPicture[i].BackgroundImageLayout = ImageLayout.Zoom;
                    listaPicture[i].BackgroundImage = lista[i + valor].img1;
                    
                    listaPicture2[i].BackgroundImageLayout = ImageLayout.Zoom;
                    listaPicture2[i].BackgroundImage = lista[i + valor].img2;
                    
                    listaPicture3[i].BackgroundImageLayout = ImageLayout.Zoom;
                    listaPicture3[i].BackgroundImage = lista[i + valor].img3;

                    listaPrecios[i].Text = "$ " + lista[i + valor].precio.ToString();
                    listaNombres[i].Text = lista[i + valor].nombre;
                    listaDesc[i].Text = lista[i + valor].descripcion;
                }
            }

        }

        private void btIzquierda_Click(object sender, EventArgs e)
        {
            if (valor == 0)
            {
                MessageBox.Show("No hay mas articulos para mostrar", "Error");
            }
            else
            {
                valor--;
                for (int i = 0; i < 4; i++)
                {
                    listaPicture[i].BackgroundImageLayout = ImageLayout.Zoom;
                    listaPicture[i].BackgroundImage = lista[i + valor].img1;

                    listaPicture2[i].BackgroundImageLayout = ImageLayout.Zoom;
                    listaPicture2[i].BackgroundImage = lista[i + valor].img2;

                    listaPicture3[i].BackgroundImageLayout = ImageLayout.Zoom;
                    listaPicture3[i].BackgroundImage = lista[i + valor].img3;

                    listaPrecios[i].Text = "$ " + lista[i + valor].precio.ToString();
                    listaNombres[i].Text = lista[i + valor].nombre;
                    listaDesc[i].Text = lista[i + valor].descripcion;
                }
            }
        }
    }
}
