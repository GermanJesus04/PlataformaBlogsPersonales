using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaBlogsPersonales.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaBlogsPersonales.Infraestructura.EntityConfiguration
{
    public class EntiquetaConfiguracion : IEntityTypeConfiguration<Etiqueta> 
    {
        public void Configure(EntityTypeBuilder<Etiqueta> builder)
        {
            builder.ToTable("ETIQUETA");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("NOMBRE");

            builder.Property(e => e.Descripcion)
                .IsRequired(false)
                .HasMaxLength(350)
                .HasColumnName("DESCRIPCION");

            builder.Property(e => e.Slug)
                .IsRequired()
                .HasMaxLength(300)
                .HasColumnName("SLUG");

            // Modelo Entidad - Relacion
            builder.HasMany(e => e.ArticuloEtiquetas)
                .WithOne(ae => ae.Etiqueta)
                .HasForeignKey(ae => ae.IdEtiqueta)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
