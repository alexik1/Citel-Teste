using Citel_Teste_Entity.Models;

namespace Citel_Teste_Infrastructure.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> GetAllCategoria();
        Task<Categoria?> GetByIdCategoria(int id);

        Task<Categoria?> GetByNameCategoria(string nome);

        Task<Categoria> CreateCategoria(Categoria categoria);

        Task<Categoria> UpdateCategoria(int id, Categoria categoria);

        Task DeleteCategoria(int id);
    }
}
