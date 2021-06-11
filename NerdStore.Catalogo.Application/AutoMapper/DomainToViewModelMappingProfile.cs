using System.Reflection.Emit;
using AutoMapper;
using NerdStore.Catalogo.Application.ViewModels;
using NerdStore.Catalogo.Domain;
using Newtonsoft.Json.Linq;

namespace NerdStore.Catalogo.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(p => p.Largura,
                    v => v.MapFrom(s => s.Dimensoes.Largura))
                .ForMember(p => p.Altura,
                    v => v.MapFrom(s => s.Dimensoes.Altura))
                .ForMember(p => p.Profundidade,
                    v => v.MapFrom(s => s.Dimensoes.Profundidade));

            CreateMap<Categoria, CategoriaViewModel>();
        }
    }
}