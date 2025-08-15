using PlataformaBlogsPersonales.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaBlogsPersonales.Model.DTOs.CategoriaDTOs
{
    public class CategoriaDTO
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public string Slug { get; set; }
    }
}
