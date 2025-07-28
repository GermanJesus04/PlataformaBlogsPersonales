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
    public class ArticuloConfiguracion : IEntityTypeConfiguration<Articulo>
    {
        public void Configure(EntityTypeBuilder<Articulo> builder)
        {
            builder.ToTable("ARTICULO");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Titulo)
                .IsRequired()
                .HasMaxLength(50); 
            builder.Property(a => a.Contenido)
                .IsRequired();
            builder.Property(a => a.Resumen)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(a => a.FechaCreacion)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
            
            //Modelo Entidad - Relacion
            builder.HasOne(a=> a.Categorias)
                .WithMany()
                .HasForeignKey(a => a.IdCategoria)
                .OnDelete(DeleteBehavior.Cascade);


        } 
    
    }
}
