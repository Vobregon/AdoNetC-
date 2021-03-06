//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AprendiendoEntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Producto
    {
        public Producto()
        {
            this.Detalles = new HashSet<Detalle>();
        }
    
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public Nullable<int> IdProveedor { get; set; }
        public Nullable<int> IdCategoría { get; set; }
        public string CantidadPorUnidad { get; set; }
        public Nullable<decimal> PrecioUnidad { get; set; }
        public Nullable<short> UnidadesEnExistencia { get; set; }
        public Nullable<short> UnidadesEnPedido { get; set; }
        public Nullable<int> NivelNuevoPedido { get; set; }
        public bool Suspendido { get; set; }
    
        public virtual Categorías Categorías { get; set; }
        public virtual ICollection<Detalle> Detalles { get; set; }
        public virtual Proveedore Proveedore { get; set; }
    }
}
