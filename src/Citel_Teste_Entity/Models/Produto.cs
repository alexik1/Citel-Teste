using System.ComponentModel.DataAnnotations.Schema;

namespace Citel_Teste_Entity.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
