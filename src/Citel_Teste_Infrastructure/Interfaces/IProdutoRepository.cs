using Citel_Teste_Entity.Models;

namespace Citel_Teste_Infrastructure.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetAllProduto();
        Task<IEnumerable<Produto>> GetByCategoriaIdProduto(int categoriaId);

        Task<Produto?> GetByIdProduto(int id);

        Task<Produto?> GetByNameProduto(string nome);

        Task<Produto> CreateProduto(Produto produto);

        Task<Produto> UpdateProduto(int id, Produto produto);

        Task DeleteProduto(int id);
    }
}
