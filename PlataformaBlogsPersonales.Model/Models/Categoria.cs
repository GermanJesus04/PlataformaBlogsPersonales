using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaBlogsPersonales.Model.Models
{
    public class Categoria: EntidadBase
    {
        public Categoria() { 
            Id = Guid.NewGuid();
            FechaCreacion = DateTime.UtcNow;
            UsuarioCreacion = "Sistema";

        }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Slug { get; set; }
        public ICollection<Articulo> Articulos { get; set; }
    }
}
