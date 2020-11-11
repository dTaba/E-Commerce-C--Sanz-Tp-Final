using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Commerce
{
    class daoCliente
    {
        public static bool logearUsuario(string usuario, string clave, string correo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                SqlConnection con = new SqlConnection(Helper.connectionString);
                con.Open();

                cmd.Connection = con;
                cmd.CommandText = @"Select id from Clientes where usuario = '" + usuario + "' and clave='" + clave + "' and mail='" + correo + "'";

                var result = cmd.ExecuteScalar();

                if (result == null)
                {
                    con.Close();
                    return false;
                }
                else
                {
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter("Select * from Clientes where usuario = '" + usuario + "' and clave='" + clave + "' and mail='" + correo + "'", Helper.connectionString))
                    {
                        da.Fill(dt);
                    }

                    dtoCliente datosLogeados = new dtoCliente();

                    foreach (DataRow dr in dt.Rows)
                    {
                        if (!dr.IsNull("id")) datosLogeados.id = (int)dr["id"];
                        if (!dr.IsNull("usuario")) datosLogeados.usuario = (string)dr["usuario"];
                        if (!dr.IsNull("clave")) datosLogeados.clave = (string)dr["clave"];
                        if (!dr.IsNull("mail")) datosLogeados.email = (string)dr["mail"];
                        if (!dr.IsNull("nombre")) datosLogeados.nombre = (string)dr["nombre"];
                        if (!dr.IsNull("nacimiento")) datosLogeados.nacimiento = (string)dr["nacimiento"];
                        if (!dr.IsNull("cantPedidos")) datosLogeados.pedidosrealizados = (int)dr["cantPedidos"];
                        if (!dr.IsNull("nivel")) datosLogeados.nivel = (int)dr["nivel"];
                        if (!dr.IsNull("puntos")) datosLogeados.puntos = (int)dr["puntos"];
                        if (!dr.IsNull("apellido")) datosLogeados.apellido = (string)dr["apellido"];
                        if (!dr.IsNull("direccion")) datosLogeados.direccion = (string)dr["direccion"];
                        if (!dr.IsNull("telefono")) datosLogeados.telefono = (string)dr["telefono"];
                    }

                    con.Close();

                    Helper.LogearUsuario(datosLogeados);
                    return true;
                }
            }
        }

        public static void nuevaCompra(List<dtoArticulo> productos)
        {
            SqlConnection con = new SqlConnection(Helper.connectionString);
            con.Open();
            
            string nuevaCompra = "update Clientes set cantPedidos=" + Helper.GetNext("Clientes","cantPedidos") + "where id=" + Helper.usuarioLogeado.id;
            SqlCommand cmd = new SqlCommand(nuevaCompra, con);
            cmd.ExecuteNonQuery();

            for(int i = 0; i <= productos.Count-1; i++)
            {
                string reducirStock = "update Articulos set stock=" + Helper.GetNext("Articulos", "stock") + "where id=" + productos[i].id;
                SqlCommand cmd2 = new SqlCommand(reducirStock, con);
                cmd2.ExecuteNonQuery();
            }


            for (int i = 0; i <= productos.Count-1; i++)
            {
                string aumentarVentas = "update Articulos set vendidos=" + Helper.GetNext("Articulos", "vendidos") + "where id=" + productos[i].id;
                SqlCommand cmd3 = new SqlCommand(aumentarVentas, con);
                cmd3.ExecuteNonQuery();
            }

            con.Close();
         }

        public static void actualizarCliente(string direccion, string telefono, string email, string clave)
        {
            SqlConnection con = new SqlConnection(Helper.connectionString);
            con.Open();

            string actualizar = "update Clientes set direccion='" + direccion + "', clave='" + clave + "', telefono='" + telefono + "', mail='" + email + "' where id=" + Helper.usuarioLogeado.id;
            SqlCommand cmd = new SqlCommand(actualizar, con);
            cmd.ExecuteNonQuery();

            con.Close();

            actualizarDatos();
        }

        public static void actualizarDatos()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                SqlConnection con = new SqlConnection(Helper.connectionString);
                con.Open();
                
                DataTable dt = new DataTable();
                    
                using (SqlDataAdapter da = new SqlDataAdapter("Select * from Clientes where id=" + Helper.usuarioLogeado.id, Helper.connectionString))
                {
                    da.Fill(dt);
                }

                dtoCliente datosLogeados = new dtoCliente();

                foreach (DataRow dr in dt.Rows)
                {
                    if (!dr.IsNull("id")) datosLogeados.id = (int)dr["id"];
                    if (!dr.IsNull("usuario")) datosLogeados.usuario = (string)dr["usuario"];
                    if (!dr.IsNull("clave")) datosLogeados.clave = (string)dr["clave"];
                    if (!dr.IsNull("mail")) datosLogeados.email = (string)dr["mail"];
                    if (!dr.IsNull("nombre")) datosLogeados.nombre = (string)dr["nombre"];
                    if (!dr.IsNull("nacimiento")) datosLogeados.nacimiento = (string)dr["nacimiento"];
                    if (!dr.IsNull("cantPedidos")) datosLogeados.pedidosrealizados = (int)dr["cantPedidos"];
                    if (!dr.IsNull("nivel")) datosLogeados.nivel = (int)dr["nivel"];
                    if (!dr.IsNull("puntos")) datosLogeados.puntos = (int)dr["puntos"];
                    if (!dr.IsNull("apellido")) datosLogeados.apellido = (string)dr["apellido"];
                    if (!dr.IsNull("direccion")) datosLogeados.direccion = (string)dr["direccion"];
                    if (!dr.IsNull("telefono")) datosLogeados.telefono = (string)dr["telefono"];
                }

                con.Close();

                Helper.LogearUsuario(datosLogeados);
                }
            }
        }

    }
