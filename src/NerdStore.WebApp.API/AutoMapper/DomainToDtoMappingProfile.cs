using AutoMapper;
using NerdStore.Catalogo.Domain;
using NerdStore.WebApp.API.DTOs;

namespace NerdStore.WebApp.API.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Categoria, CategoriaDto>();

            CreateMap<Produto, ProdutoDto>()
                .ForMember(x => x.Largura, y => y.MapFrom(z => z.Dimensoes.Largura))
                .ForMember(x => x.Altura, y => y.MapFrom(z => z.Dimensoes.Altura))
                .ForMember(x => x.Profundidade, y => y.MapFrom(z => z.Dimensoes.Profundidade));
        }
    }
}