using Citel_Teste_Core.Interfaces;
using Citel_Teste_Entity.Models;
using Citel_Teste_Infrastructure.Interfaces;

namespace Citel_Teste_Core.Services
{
    public class ProdutoService : IProdutoService
    {
        private IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }


        public async Task<IEnumerable<Produto>> GetAllProduto()
        {
            var result = await _produtoRepository.GetAllProduto();
            return result;
        }

        public async Task<IEnumerable<Produto>> GetByCategoriaIdProduto(int categoriaId)
        {
            var result = await _produtoRepository.GetByCategoriaIdProduto(categoriaId);
            return result;
        }

        public async Task<Produto?> GetByIdProduto(int id)
        {
            var result = await _produtoRepository.GetByIdProduto(id);
            return result;
        }

        public async Task<Produto?> GetByNameProduto(string nome)
        {
            var result = await _produtoRepository.GetByNameProduto(nome);
            return result;
        }

        public async Task<Produto> CreateProduto(Produto produto)
        {
            var result = await _produtoRepository.CreateProduto(produto);
            return result;
        }

        public async Task<Produto> UpdateProduto(int id, Produto produto)
        {
            var result = await _produtoRepository.UpdateProduto(id, produto);
            return result;
        }

        public async Task DeleteProduto(int id)
        {
            await _produtoRepository.DeleteProduto(id);
        }
    }
}
