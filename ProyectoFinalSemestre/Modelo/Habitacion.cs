//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoFinalSemestre.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Habitacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Habitacion()
        {
            this.Reservacion = new HashSet<Reservacion>();
        }
    
        public int Numero { get; set; }
        public int Capacidad { get; set; }
        public int Precio { get; set; }
        public string Descripcion { get; set; }
        public int Estado_Habi { get; set; }
        public Nullable<int> Cuarto { get; set; }
    
        public virtual Estado_Habi Estado_Habi1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservacion> Reservacion { get; set; }
    }
}
