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
        public int subtotal = 0;
        public int contadorinicio = 0;

        List<dtoArticulo> lista = new List<dtoArticulo>();
        List<dtoArticulo> listaFiltro = new List<dtoArticulo>();
        List<dtoArticulo> carrito = new List<dtoArticulo>();

        List<Panel> listaPicture = new List<Panel>();
        List<Panel> listaPicture2 = new List<Panel>();
        List<Panel> listaPicture3 = new List<Panel>();
        List<Panel> listaPaneles = new List<Panel>();

        List<Label> listaPrecios = new List<Label>();
        List<Label> listaNombres = new List<Label>();
        List<Label> listaDesc = new List<Label>();

        List<string> listaCategorias = new List<string>();

        public Menu()
        {
            InitializeComponent();
            lista = daoArticulo.cargarImagenesDestacadas();
            listaCategorias = daoArticulo.obtenerCategorias();
            
            listaPicture = new List<Panel> { img1, img2, img3, img4 };
            listaPicture2 = new List<Panel> { img12, img22, img32, img42 };
            listaPicture3 = new List<Panel> { img13, img23, img33, img43 };
            listaPaneles = new List<Panel> { panelProducto1, panelProducto2, panelProducto3, panelProducto4};
        
            listaPrecios = new List<Label> { lblPrecio1, lblPrecio2, lblPrecio3, lblPrecio4 };
            listaNombres = new List<Label> { lblProducto1, lblProducto2, lblProducto3, lblProducto4 };
            listaDesc = new List<Label> { lblDesc1, lblDesc2, lblDesc3, lblDesc4 };
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
            
            if (carrito.Count == 0)
            {
                lblSubtotal.Text = "Subtotal: $ 0";
                lblCarrito.Text = "0 Productos";
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
                editarPerfil editar = new editarPerfil(this);
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

            listaFiltro.Clear();

            foreach (string categoria in listaCategorias)
            {
                cbCategorias.Items.Add(categoria);
            }

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

        private void btDerecha_Click(object sender, EventArgs e)
        {

            if (listaFiltro.Count >= 1)
            {
                if (valor == listaFiltro.Count - 4)
                {
                    MessageBox.Show("No hay mas articulos para mostrar", "Error");
                }
                else
                {
                    valor++;
                    for (int i = 0; i < 4; i++)
                    {
                        listaPicture[i].BackgroundImageLayout = ImageLayout.Zoom;
                        listaPicture[i].BackgroundImage = listaFiltro[i + valor].img1;

                        listaPicture2[i].BackgroundImageLayout = ImageLayout.Zoom;
                        listaPicture2[i].BackgroundImage = listaFiltro[i + valor].img2;

                        listaPicture3[i].BackgroundImageLayout = ImageLayout.Zoom;
                        listaPicture3[i].BackgroundImage = listaFiltro[i + valor].img3;

                        listaPrecios[i].Text = "$ " + listaFiltro[i + valor].precio.ToString();
                        listaNombres[i].Text = listaFiltro[i + valor].nombre;
                        listaDesc[i].Text = listaFiltro[i + valor].descripcion;
                    }
                }
            }
            else
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
            

        }

        private void btIzquierda_Click(object sender, EventArgs e)
        {
            if (listaFiltro.Count >= 1)
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
                        listaPicture[i].BackgroundImage = listaFiltro[i + valor].img1;

                        listaPicture2[i].BackgroundImageLayout = ImageLayout.Zoom;
                        listaPicture2[i].BackgroundImage = listaFiltro[i + valor].img2;

                        listaPicture3[i].BackgroundImageLayout = ImageLayout.Zoom;
                        listaPicture3[i].BackgroundImage = listaFiltro[i + valor].img3;

                        listaPrecios[i].Text = "$ " + listaFiltro[i + valor].precio.ToString();
                        listaNombres[i].Text = listaFiltro[i + valor].nombre;
                        listaDesc[i].Text = listaFiltro[i + valor].descripcion;
                    }

                }
            }
            else
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

        private void btCarrito1_Click(object sender, EventArgs e)
        {
            if (Helper.usuarioLogeado != null)
            {
                if (listaFiltro.Count >= 1)
                {
                    MessageBox.Show(listaFiltro[0 + valor].nombre + " agregado al carrito con exito", "CARRITO");
                    carrito.Add(listaFiltro[0 + valor]);
                    subtotal = subtotal + Convert.ToInt32((listaFiltro[0 + valor].precio));
                    lblSubtotal.Text = "Subtotal: $ " + subtotal;
                    lblCarrito.Text = carrito.Count + " Productos";
                }
                else
                {
                    MessageBox.Show(lista[0 + valor].nombre + " agregado al carrito con exito", "CARRITO");
                    carrito.Add(lista[0 + valor]);
                    subtotal = subtotal + Convert.ToInt32((lista[0 + valor].precio));
                    lblSubtotal.Text = "Subtotal: $ " + subtotal;
                    lblCarrito.Text = carrito.Count + " Productos";
                }
            }
            else
            {
                MessageBox.Show("Necesita logearse para agregar productos al carrito");
            }

        }

        private void btCarrito_Click(object sender, EventArgs e)
        {
            if (carrito.Count > 0)
            {
                carrito form = new carrito(carrito, this);
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("No hay nada en el carrito", "ERROR");
            }
        }

        private void btCarrito2_Click(object sender, EventArgs e)
        {
            if (Helper.usuarioLogeado != null)
            {
                if (listaFiltro.Count >= 1)
                {
                    MessageBox.Show(listaFiltro[1 + valor].nombre + " agregado al carrito con exito", "CARRITO");
                    carrito.Add(listaFiltro[1 + valor]);
                    subtotal = subtotal + Convert.ToInt32((listaFiltro[1 + valor].precio));
                    lblSubtotal.Text = "Subtotal: $ " + subtotal;
                    lblCarrito.Text = carrito.Count + " Productos";
                }
                else
                {
                    MessageBox.Show(lista[1 + valor].nombre + " agregado al carrito con exito", "CARRITO");
                    carrito.Add(lista[1 + valor]);
                    subtotal = subtotal + Convert.ToInt32((lista[1 + valor].precio));
                    lblSubtotal.Text = "Subtotal: $ " + subtotal;
                    lblCarrito.Text = carrito.Count + " Productos";
                }
            }
            else
            {
                MessageBox.Show("Necesita logearse para agregar productos al carrito");
            }

        }

        private void btCarrito3_Click(object sender, EventArgs e)
        {
            if (Helper.usuarioLogeado != null)
            {
                if (listaFiltro.Count >= 1)
                {
                    MessageBox.Show(listaFiltro[2 + valor].nombre + " agregado al carrito con exito", "CARRITO");
                    carrito.Add(listaFiltro[2 + valor]);
                    subtotal = subtotal + Convert.ToInt32((listaFiltro[2 + valor].precio));
                    lblSubtotal.Text = "Subtotal: $ " + subtotal;
                    lblCarrito.Text = carrito.Count + " Productos";
                }
                else
                {
                    MessageBox.Show(lista[2 + valor].nombre + " agregado al carrito con exito", "CARRITO");
                    carrito.Add(lista[2 + valor]);
                    subtotal = subtotal + Convert.ToInt32((lista[2 + valor].precio));
                    lblSubtotal.Text = "Subtotal: $ " + subtotal;
                    lblCarrito.Text = carrito.Count + " Productos";
                }
            }
            else
            {
                MessageBox.Show("Necesita logearse para agregar productos al carrito");
            }

        }

        private void btCarrito4_Click(object sender, EventArgs e)
        {
            if (Helper.usuarioLogeado != null)
            {
                if (listaFiltro.Count >= 1)
                {
                    MessageBox.Show(listaFiltro[3 + valor].nombre + " agregado al carrito con exito", "CARRITO");
                    carrito.Add(listaFiltro[3 + valor]);
                    subtotal = subtotal + Convert.ToInt32((listaFiltro[3 + valor].precio));
                    lblSubtotal.Text = "Subtotal: $ " + subtotal;
                    lblCarrito.Text = carrito.Count + " Productos";
                }
                else
                {
                    MessageBox.Show(lista[3 + valor].nombre + " agregado al carrito con exito", "CARRITO");
                    carrito.Add(lista[3 + valor]);
                    subtotal = subtotal + Convert.ToInt32((lista[3 + valor].precio));
                    lblSubtotal.Text = "Subtotal: $ " + subtotal;
                    lblCarrito.Text = carrito.Count + " Productos";
                }
            }
            else
            {
                MessageBox.Show("Necesita logearse para agregar productos al carrito");
            }

        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            if (txBusqueda.Text != "")
            {
                string where = "nombre like '" + txBusqueda.Text + "%'";
                filtrarArticulos(where);

                lblProductos.Text = "Búsqueda: " + txBusqueda.Text;
                txBusqueda.Text = "";
            }
            else 
            {
                MessageBox.Show("La barra de busqueda esta vacia", "Error");
            }
        }

        private void btAplicarFiltros_Click(object sender, EventArgs e)
        {
            if (cbCategorias.Text == "")
            {
                if (filtroPrecio.Value == 0)
                {
                    MessageBox.Show("El filtro de precio debe ser mayor a 0", "Error");
                }
                else
                {
                    string where = "precio < " + filtroPrecio.Value + " order by precio";
                    filtrarArticulos(where);
                }
            }
            else if (filtroPrecio.Value == 0)
            {
                string where = "categoria='" + cbCategorias.Text + "'";
                filtrarArticulos(where);
            }
            else
            {
                string where = "categoria='" + cbCategorias.Text + "' and precio <= " + filtroPrecio.Value + " order by precio";
                filtrarArticulos(where);
            }
        }

        private void filtrarArticulos(string where)
        {
            listaFiltro = daoArticulo.cargarFiltro(where);

            for (int i = 0; i < 4; i++)
            {
                if (i > listaFiltro.Count - 1)
                {
                    listaPaneles[i].Visible = false;
                    btIzquierda.Visible = false;
                    btDerecha.Visible = false;

                }
                else
                {
                    btIzquierda.Visible = true;
                    btDerecha.Visible = true;

                    listaPaneles[i].Visible = true;
                    listaPicture[i].BackgroundImageLayout = ImageLayout.Zoom;
                    listaPicture[i].BackgroundImage = listaFiltro[i].img1;
                    listaPicture2[i].BackgroundImage = listaFiltro[i].img2;
                    listaPicture3[i].BackgroundImage = listaFiltro[i].img3;

                    listaPrecios[i].Text = "$ " + listaFiltro[i].precio.ToString();
                    listaNombres[i].Text = listaFiltro[i].nombre;
                    listaDesc[i].Text = listaFiltro[i].descripcion;
                }

            }
            valor = 0;
        }

        private void Menu_Activated(object sender, EventArgs e)
        {
            if (carrito.Count == 0)
            {
                subtotal = 0;
                lblSubtotal.Text = "Subtotal: $ " + subtotal;
                lblCarrito.Text = "0 Productos";
            }
        }
    }
}
