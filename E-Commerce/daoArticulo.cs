using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Commerce
{
    class daoArticulo
    {
        public static List<dtoArticulo> cargarImagenesDestacadas()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                SqlConnection con = new SqlConnection(Helper.connectionString);
                con.Open();

                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter("select * from Articulos order by vendidos", Helper.connectionString))
                {
                    da.Fill(dt);
                }

                List<dtoArticulo> lista = new List<dtoArticulo>();

                foreach (DataRow dr in dt.Rows)
                {
                    dtoArticulo articulo = new dtoArticulo();
                    
                    if (!dr.IsNull("id")) articulo.id = (int)dr["id"];
                    if (!dr.IsNull("nombre")) articulo.nombre = (string)dr["nombre"];
                    if (!dr.IsNull("descripcion")) articulo.descripcion = (string)dr["descripcion"];
                    if (!dr.IsNull("precio")) articulo.precio = (decimal)dr["precio"];
                    
                    if(!dr.IsNull("img1"))
                    {
                        byte[] byteImage = (byte[])dr["img1"];
                        
                        using (MemoryStream ms = new MemoryStream(byteImage))
                        {
                            Image img = new Bitmap(ms);
                            articulo.img1 = img;
                        }
                    }
                    else
                    {
                        articulo.img1 = null;
                    }

                    if (!dr.IsNull("img2"))
                    {
                        byte[] byteImage = (byte[])dr["img2"];

                        using (MemoryStream ms = new MemoryStream(byteImage))
                        {
                            Image img = new Bitmap(ms);
                            articulo.img2 = img;
                        }
                    }
                    else
                    {
                        articulo.img2 = null;
                    }
                    
                    if (!dr.IsNull("img3"))
                    {
                        byte[] byteImage = (byte[])dr["img3"];

                        using (MemoryStream ms = new MemoryStream(byteImage))
                        {
                            Image img = new Bitmap(ms);
                            articulo.img3 = img;
                        }
                    }
                    else
                    {
                        articulo.img3 = null;
                    }

                    if (!dr.IsNull("vendidos")) articulo.vendidos = (decimal)dr["vendidos"];
                    if (!dr.IsNull("stock")) articulo.stock = (decimal)dr["stock"];
                    if (!dr.IsNull("categoria")) articulo.categoria = (string)dr["categoria"];
                    if (!dr.IsNull("marca")) articulo.marca = (string)dr["marca"];
                    if (!dr.IsNull("modelo")) articulo.modelo = (string)dr["modelo"];

                    lista.Add(articulo);
                }

                con.Close();

                return lista;
            }
        }
    }
}
