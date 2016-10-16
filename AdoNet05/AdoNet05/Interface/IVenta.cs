using AdoNet05.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet05.Interface
{
   public  interface IVenta
    {
       // definir la firma
       int registrar(VentaDTO o);
    }
}
