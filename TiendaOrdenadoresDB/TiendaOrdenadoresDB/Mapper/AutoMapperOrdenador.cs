using AutoMapper;
using TiendaOrdenadoresDB.Models;

namespace TiendaOrdenadoresDB.Mapper
{
    public class AutoMapperOrdenador : Profile
    {
        public AutoMapperOrdenador()
        {

            CreateMap< TiendaOrdenadores.Ordenador, Ordenador>()
                .ForMember(dest => dest.OrdenadorComponentes, opt => opt.MapFrom((src, dest, destMember, context) =>
                    {
                        var mapper = context.Mapper;
                        var componentes = new List<OrdenadorComponente>()
                        {
                            new OrdenadorComponente { Componente = mapper.Map<Componente>(src.Procesador) },
                            new OrdenadorComponente { Componente = mapper.Map<Componente>(src.Memorizador) },
                            new OrdenadorComponente { Componente = mapper.Map<Componente>(src.Guardador) }
                        };
                        return componentes;

                    }
                
                ));
        }
    }
}
