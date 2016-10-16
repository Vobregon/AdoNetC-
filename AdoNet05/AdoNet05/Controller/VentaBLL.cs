using AdoNet05.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AdoNet05.Entity;

namespace AdoNet05.Controller
{
    public class VentaBLL
    {
        // atributo
        private VentaDAO dao = new VentaDAO();

        public VentaBLL()
        { 
        }
        // metodos
        public DataTable ListaClientes()
        {
            return dao.lista1();
        }

        public DataTable ListaEmpleados()
        {
            return dao.lista2();
        }

        public DataTable ListaProductos()
        {
            return dao.lista3();
        }

        public DataTable DatosProducto(int id)
         {
             return dao.lista4(id);
        }

        public int RegistrarVenta(VentaDTO v)
        {
            return dao.registrar(v);
        }


    }
}
