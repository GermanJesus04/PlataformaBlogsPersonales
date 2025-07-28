using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaBlogsPersonales.Model.Models
{
    public class ArticuloEtiqueta
    {
        public Guid IdArticulo { get; set; }
        public Articulo Articulo { get; set; }
        public Guid IdEtiqueta { get; set; }
        public Etiqueta Etiqueta { get; set; }
    }
}
