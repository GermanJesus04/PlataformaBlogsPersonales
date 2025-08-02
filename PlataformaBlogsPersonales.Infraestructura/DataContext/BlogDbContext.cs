using Microsoft.EntityFrameworkCore;
using PlataformaBlogsPersonales.Infraestructura.EntityConfiguration;
using PlataformaBlogsPersonales.Model.Models;

namespace PlataformaBlogsPersonales.Infraestructura.DataContext;

public class BlogDbContext(DbContextOptions<BlogDbContext> options) : DbContext(options)
{
    public DbSet<Articulo> Articulos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Etiqueta> Etiquetas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ArticuloConfiguracion());
        modelBuilder.ApplyConfiguration(new ArticuloEtiquetaConfigutacion());
        modelBuilder.ApplyConfiguration(new CategoriaConfiguracion());
        modelBuilder.ApplyConfiguration(new EntiquetaConfiguracion());

        base.OnModelCreating(modelBuilder);
    }

}

