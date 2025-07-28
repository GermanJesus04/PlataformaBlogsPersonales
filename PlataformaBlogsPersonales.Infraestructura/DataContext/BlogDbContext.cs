using Microsoft.EntityFrameworkCore;
using PlataformaBlogsPersonales.Infraestructura.EntityConfiguration;
using PlataformaBlogsPersonales.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaBlogsPersonales.Infraestructura.DataContext
{
    public class BlogDbContext(DbContextOptions<BlogDbContext> options) : DbContext(options)
    {
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Etiqueta> Etiquetas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticuloConfiguracion());
            modelBuilder.ApplyConfiguration(new ArticuloEtiquetaConfigutacion());

            base.OnModelCreating(modelBuilder);
        }
        
    }
}
