using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaBlogsPersonales.Model.Models
{
    public class Etiqueta : EntidadBase
    {
        public Etiqueta()
        {
            Id = Guid.NewGuid();
            FechaCreacion = DateTime.UtcNow;
            UsuarioCreacion = "Sistema"; // Default user, can be changed later
        }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Slug { get; set; }
        public ICollection<Articulo> Articulos { get; set; }

    }
}
