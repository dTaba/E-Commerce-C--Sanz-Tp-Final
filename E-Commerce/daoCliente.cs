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
    }
}
