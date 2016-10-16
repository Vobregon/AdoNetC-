using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet02.Entity
{
    public class EmpleadoDTO
    {
        // propiedades
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string  Cargo { get; set; }
    }
}
