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
        internal static string connectionString = (@"server=LAPTOP-LHBBVFT9\SQLEXPRESS;Database=ArticulosECommerce;Trusted_Connection=True");
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
    }
}
