using AutoMapper;
using TiendaOrdenadores.Componentes.Almacenadores.Guardadores;
using TiendaOrdenadores.Componentes.Almacenadores.Memorizadores;
using TiendaOrdenadores.Componentes.Procesadores;
using TiendaOrdenadoresDB.Models;

namespace TiendaOrdenadoresDB.Mapper
{
    public class AutoMapperComponentes : Profile
    {
        public AutoMapperComponentes()
        {
            CreateMap<Componente, Procesador>()
                .ForMember(dest => dest.Cores, opt => opt.MapFrom(src => src.Almacenamiento))
                .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Description));
            CreateMap<Componente, Memorizador>()
                .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Description));
            CreateMap<Componente, Guardador>()
                .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Description));

            CreateMap<Guardador, Componente>()
                .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => 2))
                .ForMember(dest => dest.UnidadMedida, opt => opt.MapFrom(src => "Bytes"))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Descripcion));
            CreateMap<Memorizador, Componente>()
                .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => 1))
                .ForMember(dest => dest.UnidadMedida, opt => opt.MapFrom(src => "Bytes"))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Descripcion));
            CreateMap<Procesador, Componente>()
                .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.UnidadMedida, opt => opt.MapFrom(src => "Cores"))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Descripcion))
                .ForMember(dest => dest.Almacenamiento, opt => opt.MapFrom(src => src.Cores));
        }

    }
}
