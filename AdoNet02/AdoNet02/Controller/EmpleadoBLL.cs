using AdoNet02.Entity;
using AdoNet02.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet02.Controller
{
   public class EmpleadoBLL
    {

       public List<EmpleadoDTO> EmpleadoListar()
       {
           return new EmpleadoDAO().ListaEmpleados();
       }

    }
}
