using AutoMapper;
using PlataformaBlogsPersonales.Model.DTOs.ArticuloDTOs;
using PlataformaBlogsPersonales.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

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
