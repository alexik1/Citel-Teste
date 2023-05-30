using Citel_Teste_Core.Interfaces;
using Citel_Teste_Entity.Models;
using Citel_Teste_Infrastructure.Interfaces;

namespace Citel_Teste_Core.Services
{
    public class CategoriaService : ICategoriaService
    {
        private ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IEnumerable<Categoria>> GetAllCategoria()
        {
            var result = await _categoriaRepository.GetAllCategoria();
            return result;
        }
        public async Task<Categoria?> GetByIdCategoria(int id)
        {
            var result = await _categoriaRepository.GetByIdCategoria(id);
            return result;
        }

        public async Task<Categoria?> GetByNameCategoria(string nome)
        {
            var result = await _categoriaRepository.GetByNameCategoria(nome);
            return result;
        }

        public async Task<Categoria> CreateCategoria(Categoria categoria)
        {
            var result = await _categoriaRepository.CreateCategoria(categoria);
            return result;
        }

        public async Task<Categoria> UpdateCategoria(int id, Categoria categoria)
        {
            var result = await _categoriaRepository.UpdateCategoria(id, categoria);
            return result;
        }

        public async Task DeleteCategoria(int id)
        {
            await _categoriaRepository.DeleteCategoria(id);
        }
    }
}
