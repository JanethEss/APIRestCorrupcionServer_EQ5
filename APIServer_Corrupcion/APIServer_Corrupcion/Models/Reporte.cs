namespace APIServer_Corrupcion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reporte
    {
        [Key]
        public int Folio_Reporte { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Descripcion { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha_Reporte { get; set; }

        [Required]
        [StringLength(45)]
        public string Status { get; set; }

        [Required]
        [StringLength(45)]
        public string Usuario { get; set; }

        //public virtual Estatus Estatu { get; set; }

        //public virtual Usuario Usuario1 { get; set; }
    }
}
