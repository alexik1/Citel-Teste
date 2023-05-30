using Citel_Teste_Entity.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Citel_Teste_Api.Dto
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public decimal Preco { get; set;}
        public int CategoriaId { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
