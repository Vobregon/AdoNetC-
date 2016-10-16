using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adonet03.Interface
{
     public interface ICrud <T>
    {
        // definir las firmas
         int create(T o);
         int update(T o);
         int delete(T o);
         List<T> readAll();
         T find(int id);
    }
}
