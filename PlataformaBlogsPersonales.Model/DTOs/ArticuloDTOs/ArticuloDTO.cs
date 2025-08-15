using PlataformaBlogsPersonales.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaBlogsPersonales.Model.DTOs.ArticuloDTOs
{
    public class ArticuloDTO
    {
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public string Resumen { get; set; }
        public string Autor { get; set; }
        public List<string> Etiquetas { get; set; } = new();
        public Guid IdCategoria { get; set; }
        public EstadoArticulo Estado { get; set; }
        public string? SlugImagen { get; set; }
        public int NumeroVisitas { get; set; }
        public bool ComentariosHabilitados { get; set; }
    }
}
