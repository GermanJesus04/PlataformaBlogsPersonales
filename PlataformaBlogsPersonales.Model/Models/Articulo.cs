using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaBlogsPersonales.Model.Models
{
    public class Articulo : EntidadBase
    {
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public string Resumen { get; set; }
        public Guid IdAutor { get; set; }
        public ICollection<Etiqueta> Etiquetas { get; set; }
        public Categoria Categorias { get; set; }
        public EstadoArticulo Estado { get; set; }
        public string SlugImagen { get; set; }
        public int NumeroVisitas { get; set; }
        public bool ComentariosHabilitados { get; set; }

    }
}
