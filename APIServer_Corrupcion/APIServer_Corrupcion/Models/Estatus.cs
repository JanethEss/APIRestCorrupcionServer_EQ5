namespace APIServer_Corrupcion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Estatus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Estatus()
        {
            //Reportes = new HashSet<Reporte>();
        }

        [Key]
        [StringLength(45)]
        public string Status { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Descripcion { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Reporte> Reportes { get; set; }
    }
    public partial class SoloEstatus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SoloEstatus()
        {
            //Reportes = new HashSet<Reporte>();
        }

        [Key]
        [StringLength(45)]
        public string Status { get; set; }        
        
    }
}
