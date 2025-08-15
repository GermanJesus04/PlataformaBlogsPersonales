using PlataformaBlogsPersonales.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaBlogsPersonales.Model.DTOs.CategoriaDTOs
{
    public class CategoriaDTO
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Slug { get; set; }
    }
}
