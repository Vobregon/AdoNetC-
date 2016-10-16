using Adonet01.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adonet01.Controller
{
    public class ProductoBLL
    {
        public DataSet ListaProductos()
        {
            return new ProductoDAO().Listar();
        }

        public DataTable ListaProductosxNombre(string nom)
        {
            return new ProductoDAO().Listar1(nom);
        }

        public DataTable ListaCategorias()
        {
            return new ProductoDAO().Listar2();
        }

        public DataTable ListaProductosxCategoria(int id)
        {
            return new ProductoDAO().Listar3(id);
        }

    }
}
