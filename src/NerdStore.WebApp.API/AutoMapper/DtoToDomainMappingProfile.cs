using AutoMapper;
using NerdStore.Catalogo.Domain;
using NerdStore.WebApp.API.DTOs;

namespace NerdStore.WebApp.API.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<CategoriaDto, Categoria>()
                .ConstructUsing(x => new Categoria(x.Nome, x.Codigo));

            CreateMap<ProdutoDto, Produto>()
                .ConstructUsing(x => new Produto(x.Nome, x.Descricao, x.Ativo, x.Valor, x.CategoriaId, x.DataCadastro,
                    x.Imagem, new Dimensoes(x.Altura, x.Largura, x.Profundidade)));
        }
    }
}