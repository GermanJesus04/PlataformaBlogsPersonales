using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaBlogsPersonales.Model.DTOs.ArticuloDTOs
{
    public class FiltroArticuloDTO
    {
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public List<string> Etiquetas { get; set; } = new();
    }
}
