using Citel_Teste_Entity.Models;
using Citel_Teste_Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Citel_Teste_Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly CitelDbContext _context;

        public CategoriaRepository(CitelDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Categoria>> GetAllCategoria()
        {
            var result = await _context.Categorias.ToListAsync();
            return result;
        }

        public async Task<Categoria?> GetByIdCategoria(int id)
        {
            var result = await _context.Categorias.FindAsync(id);
            return result;
        }

        public async Task<Categoria?> GetByNameCategoria(string nome)
        {
            var result = await _context.Categorias.FirstOrDefaultAsync(p => p.Nome == nome);
            return result;
        }

        public async Task<Categoria> CreateCategoria(Categoria categoria)
        {
            var categoriaMesmoNomeExistente = await _context.Categorias.FirstOrDefaultAsync(p => p.Nome == categoria.Nome);
            if (categoriaMesmoNomeExistente != null)
            {
                throw new Exception($"Categoria de nome {categoria.Nome} já existente.");
            }

            categoria.DataCriacao = DateTime.Now;
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> UpdateCategoria(int id, Categoria categoria)
        {
            var encontrarCategoria = _context.Categorias.FirstOrDefault(p => p.Id == id) ?? throw new Exception("Categoria Não Localizada.");

            encontrarCategoria.Nome = encontrarCategoria.Nome == categoria.Nome ? encontrarCategoria.Nome : categoria.Nome;
            encontrarCategoria.Descricao = categoria.Descricao == "string" || categoria.Descricao == null ? encontrarCategoria.Descricao : categoria.Descricao;

            _context.Categorias.Update(encontrarCategoria);
            await _context.SaveChangesAsync();
            return encontrarCategoria;
        }

        public async Task DeleteCategoria(int id)
        {
            var encontrarCategoria = _context.Categorias.FirstOrDefault(p => p.Id == id) ?? throw new Exception("Categoria Não Localizada.");

            _context.Categorias.Remove(encontrarCategoria);
            await _context.SaveChangesAsync();
        }
    }
}
