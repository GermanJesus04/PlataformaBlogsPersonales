using AutoMapper;
using PlataformaBlogsPersonales.Model.DTOs.ArticuloDTOs;
using PlataformaBlogsPersonales.Model.Models;

namespace PlataformaBlogsPersonales.Infraestructura.Mapeos
{
    public class ArticuloMapper: Profile
    {
        public ArticuloMapper() 
        {
            CreateMap<Articulo, ArticuloDTO>()
               .ReverseMap();
        }
    }
}
