using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Adonet01.DataBase;

namespace Adonet01.Model
{
    public class ProductoDAO
    {
        public DataSet Listar()
        {
            // objeto conexion
            using (var cn = AccesoDB.getConnection())
            {
                // objeto adapator de datos
                var dap = new SqlDataAdapter("select * from productos", cn);
                // objeto tabla
                var ds = new DataSet();
                // ejecutar consulta
                dap.Fill(ds, "xxx");
                return ds;
            }
        }

        public DataTable Listar1(string nombre)
        {
            using (var cn = AccesoDB.getConnection())
            {
                var dap = new SqlDataAdapter("select * from productos where NombreProducto LIKE '" + nombre + "%'", cn);
                var dt = new DataTable();
                dap.Fill(dt);
                return dt;
            }
        }

        public DataTable Listar2()
        {
            using (var cn = AccesoDB.getConnection())
            {
                var dap = new SqlDataAdapter("select * from Categorías order by NombreCategoría", cn);
                var dt = new DataTable();
                dap.Fill(dt);
                return dt;
            }
        }

        public DataTable Listar3(int idcat)
        {
            using (var cn = AccesoDB.getConnection())
            {
                var dap = new SqlDataAdapter("select * from productos where IdCategoría=" + idcat, cn);
                var dt = new DataTable();
                dap.Fill(dt);
                return dt;
            }
        }

    }
}
