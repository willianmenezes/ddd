using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        public Categoria(string nome, string codigo)
        {
            Nome = nome;
            Codigo = codigo;

            Validar();
        }

        public string Nome { get; private set; }
        public string Codigo { get; private set; }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O nome da Categoria não pode estar vazio");
            Validacoes.ValidarSeIgual(Codigo, 0, "O código da Categoria não pode ser igual a zero");
        }
    }
}