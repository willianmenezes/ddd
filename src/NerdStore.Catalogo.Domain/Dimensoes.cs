using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    public class Dimensoes
    {
        public int Altura { get; private set; }
        public int Largura { get; private set; }
        public int Profundidade { get; private set; }

        public Dimensoes(int altura, int largura, int profundidade)
        {
            Validacoes.ValidarSeMenorQue(altura, 1, "O campo Altura deve ser maior que zero");
            Validacoes.ValidarSeMenorQue(largura, 1, "O campo Largura deve ser maior que zero");
            Validacoes.ValidarSeMenorQue(profundidade, 1, "O campo Profundidade deve ser maior que zero");
            
            Altura = altura;
            Largura = largura;
            Profundidade = profundidade;
        }

        public string DescricaoFormatada()
        {
            return $"LxAxP: {Largura} x {Altura} x {Profundidade}";
        }

        public override string ToString()
        {
            return DescricaoFormatada();
        }
    }
}