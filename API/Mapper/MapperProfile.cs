using API.Dtos;
using API.ParameterIN;
using AutoMapper;
using Domain.Core.Entity;

namespace API.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Tbl_Productos, ProductoDto>().ReverseMap();
            CreateMap<Tbl_Productos, ProductoIN>().ReverseMap();
            CreateMap<Tbl_Productos_Colores, ProductoColoresDto>().ReverseMap();
            CreateMap<Tbl_Productos_Colores, ProductosColoresIn>().ReverseMap();
            CreateMap<Tbl_Colores, ColoresDto>().ReverseMap();
        }
    }
}
