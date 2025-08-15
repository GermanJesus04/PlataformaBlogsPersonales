using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PlataformaBlogsPersonales.Infraestructura.DataContext;
using PlataformaBlogsPersonales.Model.DTOs.CategoriaDTOs;
using PlataformaBlogsPersonales.Model.Models;

namespace PlataformaBlogsPersonales.Infraestructura.Servicios
{
    public class CategoriaServicios
    {
        private readonly BlogDbContext _context;
        private readonly IMapper _mapper;

        public CategoriaServicios(BlogDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<Categoria>> ListaCategorias()
        {
            try
            {
                return await _context.Categorias.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de categorías", ex);
            }
        }

        public async Task<Categoria> ObtenerCategoriaPorId(Guid id)
        {
            try
            {
                var result = await _context.Categorias.FirstOrDefaultAsync(c => c.Id == id);
                return result ?? throw new Exception($"Categoría con ID {id} no encontrada.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener la categoría con ID {id}", ex);
            }
        }

        public async Task<Categoria> CrearCategoria(CategoriaDTO categoriaDto)
        {
            try
            {
                if (categoriaDto == null)
                    throw new ArgumentNullException(nameof(categoriaDto), "La categoría no puede ser nula.");

                var categoria = _mapper.Map<Categoria>(categoriaDto);
                _context.Categorias.Add(categoria);
                await _context.SaveChangesAsync();
                return categoria;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la categoría", ex);
            }
        }


    }
}
