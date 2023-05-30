using Citel_Teste_Entity.Models;
using Citel_Teste_Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Citel_Teste_Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly CitelDbContext _context;

        public ProdutoRepository(CitelDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Produto>> GetAllProduto()
        {
            var result = await _context.Produtos.ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Produto>> GetByCategoriaIdProduto(int categoriaId)
        {
            var result = await _context.Produtos.Where(p => p.CategoriaId == categoriaId).ToListAsync();
            return result;
        }

        public async Task<Produto?> GetByIdProduto(int id)
        {
            var result = await _context.Produtos.FindAsync(id);
            return result;
        }

        public async Task<Produto?> GetByNameProduto(string nome)
        {
            var result = await _context.Produtos.FirstOrDefaultAsync(p => p.Nome == nome);
            return result;
        }

        public async Task<Produto> CreateProduto(Produto produto)
        {
            var produtoMesmoNomeExistente = await _context.Produtos.FirstOrDefaultAsync(p => p.Nome == produto.Nome);
            if (produtoMesmoNomeExistente != null)
            {
                throw new Exception($"Produto de nome {produto.Nome} já existente.");
            }

            var categoriaExistente = await _context.Categorias.FirstOrDefaultAsync(c => c.Id == produto.CategoriaId);
            if (categoriaExistente == null && produto.CategoriaId != 0)
            {
                throw new Exception($"Categoria de Id {produto.CategoriaId} não cadastrada.");
            }

            produto.DataCriacao = DateTime.Now;
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> UpdateProduto(int id, Produto produto)
        {
            var encontrarProduto = _context.Produtos.FirstOrDefault(p => p.Id == id) ?? throw new Exception("Produto Não Localizado.");

            if(produto.Nome == null || produto.Nome == "")
            {
                produto.Nome = encontrarProduto.Nome;
            }

            encontrarProduto.Nome = encontrarProduto.Nome == produto.Nome ? encontrarProduto.Nome : produto.Nome;
            encontrarProduto.Preco = produto.Preco == 0 ? encontrarProduto.Preco : produto.Preco;
            encontrarProduto.CategoriaId = produto.CategoriaId == 0 ? encontrarProduto.CategoriaId : produto.CategoriaId;

            _context.Produtos.Update(encontrarProduto);
            await _context.SaveChangesAsync();
            return encontrarProduto;
        }

        public async Task DeleteProduto(int id)
        {
            var encontrarProduto = _context.Produtos.FirstOrDefault(p => p.Id == id) ?? throw new Exception("Produto Não Localizado.");

            _context.Produtos.Remove(encontrarProduto);
            await _context.SaveChangesAsync();
        }
    }
}
