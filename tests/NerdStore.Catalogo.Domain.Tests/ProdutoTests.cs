using System;
using NerdStore.Core.DomainObjects;
using Xunit;

namespace NerdStore.Catalogo.Domain.Tests
{
    [Collection("Produto")]
    public class ProdutoTests
    {
        [Fact(DisplayName = "Verifica se as validações de produto esta concreta")]
        [Trait("Criar produto", "Validar produto")]
        public void Produto_Validar_ValidacoesDevemRetornarException()
        {
            // Arranje & Act & Assert

            var ex = Assert.Throws<DomainException>(() => new Produto(
                string.Empty, "Descricao", false, 100, Guid.NewGuid(), DateTime.Now, "imagem.jpg",
                new Dimensoes(10, 10, 10)));

            Assert.Equal("O campo Nome do Produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() => new Produto(
                "Nome", string.Empty, false, 100, Guid.NewGuid(), DateTime.Now, "imagem.jpg",
                new Dimensoes(10, 10, 10)));

            Assert.Equal("O campo Descrição do Produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() => new Produto(
                "Nome", "Descricao", false, 0, Guid.NewGuid(), DateTime.Now, "imagem.jpg",
                new Dimensoes(10, 10, 10)));

            Assert.Equal("O campo Valor do Produto não pode ser menor ou igual a zero", ex.Message);

            ex = Assert.Throws<DomainException>(() => new Produto(
                "Nome", "Descricao", false, 10, Guid.Empty, DateTime.Now, "imagem.jpg",
                new Dimensoes(10, 10, 10)));

            Assert.Equal("O campo Categoria do Produto não pode ser indefinido", ex.Message);

            ex = Assert.Throws<DomainException>(() => new Produto(
                "Nome", "Descricao", false, 10, Guid.NewGuid(), DateTime.Now, string.Empty,
                new Dimensoes(10, 10, 10)));

            Assert.Equal("O campo Imagem do Produto não pode ser vazio", ex.Message);
        }
    }
}