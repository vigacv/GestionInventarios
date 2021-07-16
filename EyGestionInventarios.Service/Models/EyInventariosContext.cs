using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EyGestionInventarios.Service.Models
{
    public partial class EyInventariosContext : DbContext
    {
        public EyInventariosContext()
        {
        }

        public EyInventariosContext(DbContextOptions<EyInventariosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Producto> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source={Connection string}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Ey")
                .HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.CodArt)
                    .HasName("PK__Producto__B3C6077C43A7CF0D");

                entity.ToTable("Producto");

                entity.Property(e => e.CodArt)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("codArt");

                entity.Property(e => e.Cant).HasColumnName("cant");

                entity.Property(e => e.DescArt)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("descArt");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
