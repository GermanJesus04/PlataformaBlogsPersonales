using AutoMapper;
using PlataformaBlogsPersonales.Model.DTOs.CategoriaDTOs;
using PlataformaBlogsPersonales.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaBlogsPersonales.Infraestructura.Mapeos
{
    public class CategoriaMapper : Profile
    {
        public CategoriaMapper()
        {
            CreateMap<Categoria, CategoriaDTO>()
                .ReverseMap();
        }
    }
}
