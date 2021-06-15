using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.WebApp.API.DTOs
{
    public class ProdutoDto
    {
        [Key] public Guid Id { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid CategoriaId { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Descricao { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public bool Ativo { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public decimal Valor { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime DataCadastro { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Imagem { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} precisa estar entre {1} e {2}")]
        public int QuantidadeEstoque { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} precisa estar entre {1} e {2}")]
        public int Altura { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} precisa estar entre {1} e {2}")]
        public int Largura { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} precisa estar entre {1} e {2}")]
        public int Profundidade { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public IEnumerable<CategoriaDto> Categorias { get; set; }
    }
}