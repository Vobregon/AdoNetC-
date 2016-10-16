using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet05.Entity
{
    public class VentaDTO
    {
        // propiedades
        public int IdVenta { get; set; }
        public string IdCliente { get; set; }
        public int IdEmpleado { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public List<DetalleDTO> Item { get; set; }
    }
}
