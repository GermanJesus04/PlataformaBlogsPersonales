using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PlataformaBlogsPersonales.Infraestructura.DataContext;
using PlataformaBlogsPersonales.Infraestructura.Servicios.Interfaces;
using PlataformaBlogsPersonales.Model.DTOs.ArticuloDTOs;
using PlataformaBlogsPersonales.Model.Models;

namespace PlataformaBlogsPersonales.Infraestructura.Servicios
{
    public class ArticuloServicios : IArticuloServicios
    {
        private readonly BlogDbContext _context;
        private readonly IMapper _mapper;
        public ArticuloServicios(BlogDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<Articulo>> ListaArticulos(FiltroArticuloDTO filtro)
        {
            try
            {
                var query = _context.Articulos.Include(e => e.ArticuloEtiquetas).AsQueryable();

                if (filtro.FechaDesde.HasValue)
                    query = query.Where(f => f.FechaCreacion >= filtro.FechaDesde.Value);

                if (filtro.FechaHasta.HasValue)
                    query = query.Where(f => f.FechaCreacion <= filtro.FechaHasta.Value);

                if (filtro.Etiquetas != null && filtro.Etiquetas.Any())
                {
                    query = query.Where(ar => ar.ArticuloEtiquetas
                                    .Any(e => filtro.Etiquetas.Contains(e.Etiqueta.Nombre)));
                }


                return await query.ToListAsync();
            } catch (Exception ex)
            {
                // Aquí podrías registrar el error o manejarlo de alguna manera
                throw new Exception("Error al obtener la lista de artículos", ex);

            }
        }

        public async Task<Articulo> ObtenerArticuloPorId(Guid id)
        {
            try
            {
                var resul = await _context.Articulos
                    .Include(e => e.Categoria)
                    .Include(e => e.ArticuloEtiquetas)
                    .ThenInclude(e => e.Etiqueta)
                    .FirstOrDefaultAsync(a => a.Id == id);

                return resul?? throw new Exception($"Artículo con ID {id} no encontrado.");
            }
            catch (Exception ex)
            {
                // Aquí podrías registrar el error o manejarlo de alguna manera
                throw new Exception($"Error al obtener el artículo con ID {id}", ex);
            }
        }
         
        public async Task<bool> CrearArticulo(ArticuloDTO articulodto)
        {
            try
            {
                var articulo = _mapper.Map<Articulo>(articulodto);
                _context.Articulos.Add(articulo);
                var result = await _context.SaveChangesAsync();
                return result > 0; 
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el artículo", ex);
            }
        }
         
        public async Task EliminarArticulo(Guid id)
        {
            try
            {
                var articulo = await _context.Articulos.FindAsync(id);
                if (articulo == null)
                {
                    throw new Exception($"Artículo con ID {id} no encontrado.");
                }
                _context.Articulos.Remove(articulo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Aquí podrías registrar el error o manejarlo de alguna manera
                throw new Exception($"Error al eliminar el artículo con ID {id}", ex);
            }
        }

        public async Task ActualizarArticulo(Guid id, Articulo articuloActualizado)
        {
            try
            {
                var articulo = await _context.Articulos.FindAsync(id);
                if (articulo == null)
                {
                    throw new Exception($"Artículo con ID {id} no encontrado.");
                }
                // Actualizar las propiedades del artículo
                articulo.Titulo = articuloActualizado.Titulo;
                articulo.Contenido = articuloActualizado.Contenido;
                articulo.FechaCreacion = articuloActualizado.FechaCreacion;
                articulo.Categoria = articuloActualizado.Categoria;
                articulo.ArticuloEtiquetas = articuloActualizado.ArticuloEtiquetas;
                _context.Articulos.Update(articulo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Aquí podrías registrar el error o manejarlo de alguna manera
                throw new Exception($"Error al actualizar el artículo con ID {id}", ex);
            }
        } 
       
    }
}
