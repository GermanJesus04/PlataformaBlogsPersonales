using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaBlogsPersonales.Model.Models;

namespace PlataformaBlogsPersonales.Infraestructura.EntityConfiguration;
public class ArticuloConfiguracion : IEntityTypeConfiguration<Articulo>
{
    public void Configure(EntityTypeBuilder<Articulo> builder)
    {
        builder.ToTable("ARTICULO");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Titulo)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("TITULO");

        builder.Property(a => a.Contenido)
            .IsRequired()
            .HasColumnName("CONTENIDO");

        builder.Property(a => a.Resumen)
            .IsRequired()
            .HasMaxLength(350)
            .HasColumnName("RESUMEN");

        builder.Property(a => a.Autor)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("AUTOR");

        builder.Property(a => a.IdCategoria)
            .IsRequired()
            .HasColumnName("ID_CATEGORIA");

        builder.Property(a => a.Estado)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20)
            .HasColumnName("ESTADO");

        builder.Property(a => a.SlugImagen)
            .IsRequired(false)
            .HasMaxLength(500)
            .HasColumnName("SLUG_IMAGEN");

        builder.Property(a => a.NumeroVisitas)
            .IsRequired()
            .HasDefaultValue(0)
            .HasColumnName("NUMERO_VISITAS");

        builder.Property(a => a.ComentariosHabilitados)
            .IsRequired()
            .HasDefaultValue(true)
            .HasColumnName("COMENTARIOS_HABILITADOS");


        //Modelo Entidad - Relacion
        builder.HasOne(a => a.Categoria)
            .WithMany()
            .HasForeignKey(a => a.IdCategoria)
            .OnDelete(DeleteBehavior.Cascade);


    }

}

