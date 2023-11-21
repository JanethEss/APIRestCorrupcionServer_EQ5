namespace APIServer_Corrupcion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            //Reportes = new HashSet<Reporte>();
        }

        [Key]
        [Column("Usuario")]
        [StringLength(45)]
        public string Usuario1 { get; set; }

        [Required]
        [StringLength(45)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(45)]
        public string ApeMaterno { get; set; }

        [Required]
        [StringLength(45)]
        public string ApePaterno { get; set; }

        [Required]
        [StringLength(15)]
        public string Contrasena { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Reporte> Reportes { get; set; }
    }
    public partial class UsuarioFiltrado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UsuarioFiltrado()
        {
            //Reportes = new HashSet<Reporte>();
        }
        
        [Required]
        [StringLength(15)]
        public string Contrasena { get; set; }

    }
}
