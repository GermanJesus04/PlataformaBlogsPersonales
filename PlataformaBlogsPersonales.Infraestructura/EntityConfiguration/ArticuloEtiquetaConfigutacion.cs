using Microsoft.EntityFrameworkCore;
using PlataformaBlogsPersonales.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaBlogsPersonales.Infraestructura.EntityConfiguration
{
    public class ArticuloEtiquetaConfigutacion : IEntityTypeConfiguration<ArticuloEtiqueta>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ArticuloEtiqueta> builder)
        {
            builder.ToTable("ARTICULO_ETIQUETA");
            builder.HasKey(ae => new { ae.IdArticulo, ae.IdEtiqueta });
            builder.Property(ae => ae.IdArticulo)
                .IsRequired()
                .HasColumnName("ID_ARTICULO");
            builder.Property(ae => ae.IdEtiqueta)
                .IsRequired()
                .HasColumnName("ID_ETIQUETA");

            // Model Entity - Relationship
            builder.HasOne(ae => ae.Articulo)
                .WithMany(a => a.ArticuloEtiquetas)
                .HasForeignKey(ae => ae.IdArticulo)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ae => ae.Etiqueta)
                .WithMany(e => e.ArticuloEtiquetas)
                .HasForeignKey(ae => ae.IdEtiqueta)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
