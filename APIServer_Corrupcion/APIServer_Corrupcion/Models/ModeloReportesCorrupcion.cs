namespace APIServer_Corrupcion.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModeloReportesCorrupcion : DbContext
    {
        public ModeloReportesCorrupcion()
            : base("name=ModeloReportesCorrupcion")
        {
        }

        public virtual DbSet<Estatus> Estatus { get; set; }
        public virtual DbSet<Reporte> Reportes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estatus>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Estatus>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            //modelBuilder.Entity<Estatus>()
            //    .HasMany(e => e.Reportes)
            //    .WithRequired(e => e.Estatu)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reporte>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Reporte>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Reporte>()
                .Property(e => e.Usuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Usuario1)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.ApeMaterno)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.ApePaterno)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Contrasena)
                .IsUnicode(false);

            //modelBuilder.Entity<Usuario>()
            //    .HasMany(e => e.Reportes)
            //    .WithRequired(e => e.Usuario1)
            //    .HasForeignKey(e => e.Usuario)
            //    .WillCascadeOnDelete(false);
        }
    }
}
