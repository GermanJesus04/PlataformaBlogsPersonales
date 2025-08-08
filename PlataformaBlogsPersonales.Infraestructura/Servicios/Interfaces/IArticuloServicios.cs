using PlataformaBlogsPersonales.Model.DTOs.ArticuloDTOs;
using PlataformaBlogsPersonales.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaBlogsPersonales.Infraestructura.Servicios.Interfaces
{
    public interface IArticuloServicios
    {
        public Task<List<Articulo>> ListaArticulos(FiltroArticuloDTO filtro);
        public Task<Articulo> ObtenerArticuloPorId(Guid id);
        public Task CrearArticulo(Articulo articulo);
        public Task EliminarArticulo(Guid id);
        public Task ActualizarArticulo(Guid id, Articulo articuloActualizado);
    }
}
