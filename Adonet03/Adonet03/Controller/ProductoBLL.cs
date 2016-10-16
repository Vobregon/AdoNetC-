using Adonet03.Entity;
using Adonet03.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adonet03.Controller
{
    public class ProductoBLL
    {
        private ProductoDAO dao = null;

        public ProductoBLL()
        {
            dao = new ProductoDAO();
        }
        // metodos de negocio

        public int ProductoAdicionar(ProductoDTO p)
        {
            return dao.create(p);
        }

        public int ProductoActualiza(ProductoDTO p)
        {
            return dao.update(p);
        }

        public int ProductoEliminar(ProductoDTO p)
        {
            return dao.delete(p);
        }

        public List<ProductoDTO> ProductoListar()
        {
            return dao.readAll();
        }

        public ProductoDTO ProductoBuscar(int id)
        {
            return dao.find(id);
        }

        public DataTable ListaProveedores()
        {
            return dao.Listar3();
        }

        public DataTable ListaCategorias()
        {
            return dao.Listar2();
        }

    }
}
