using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaBlogsPersonales.Model.Models;

namespace PlataformaBlogsPersonales.Infraestructura.EntityConfiguration
{
    public class CategoriaConfiguracion : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder) 
        {
            builder.ToTable("CATEGORIA");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("NOMBRE");

            builder.Property(c => c.Descripcion)
                .IsRequired(false)
                .HasMaxLength(350)
                .HasColumnName("DESCRIPCION");

            builder.Property(c => c.Slug)
                .IsRequired()
                .HasMaxLength(300)
                .HasColumnName("SLUG");

            // Modelo Entidad - Relacion
            builder.HasMany(c => c.Articulos)
                .WithOne(a => a.Categoria)
                .HasForeignKey(a => a.IdCategoria)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
