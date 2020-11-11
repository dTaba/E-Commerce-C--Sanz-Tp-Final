using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace E_Commerce
{
    class Helper
    {
        internal static string connectionString = @"server=LAPTOP-LHBBVFT9\SQLEXPRESS;Database=ArticulosECommerce;Trusted_Connection=True";
        internal static dtoCliente usuarioLogeado;
        internal static bool compra = false;
        internal static int cantidad;
        internal static int precio;

        internal static int GetNextId(string tableName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT IsNull(MAX(id),0) FROM " + tableName;

                    int ultimoId = (int)cmd.ExecuteScalar();

                    return ultimoId + 1;
                }
            }
        }

        internal static int GetNext(string tableName, string column)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT " + column+ " FROM " + tableName;

                    int ultimonumero = 0;
                    decimal ultimonumero2= 0;

                    if (column == "cantPedidos")
                    {
                        ultimonumero = (int)cmd.ExecuteScalar();
                    }
                    else
                    {
                        ultimonumero2 = (decimal)cmd.ExecuteScalar();
                    }


                    if (column == "stock")
                    {
                        return Convert.ToInt32(ultimonumero2) - 1;
                    }
                    else if (column == "cantPedidos")
                    {
                        return ultimonumero + 1;
                    }
                    else
                    {
                        return Convert.ToInt32(ultimonumero2) + 1;
                    }

                }
            }
        }

        internal static void LogearUsuario(dtoCliente cliente)
        {
            usuarioLogeado = cliente;
        }
    }
}
