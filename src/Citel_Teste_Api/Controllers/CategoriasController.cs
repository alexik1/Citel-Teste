using AutoMapper;
using Citel_Teste_Api.Dto;
using Citel_Teste_Core.Interfaces;
using Citel_Teste_Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace Citel_Teste_Api.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        private readonly IMapper _mapper;
        public CategoriasController(ICategoriaService categoriaService, IMapper mapper)
        {
            _categoriaService = categoriaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoriaDTO>> GetAllCategorias()
        {
            var result = await _categoriaService.GetAllCategoria();
            var listaCategoriaDto = new List<CategoriaDTO>();
            foreach (var item in result)
            {
                var itemMapped = _mapper.Map<CategoriaDTO>(item);
                listaCategoriaDto.Add(itemMapped);
            }
            return listaCategoriaDto;
        }

        [HttpGet("id/{id}")]
        public async Task<CategoriaDTO> GetByIdCategoria(int id)
        {
            var result = await _categoriaService.GetByIdCategoria(id);
            var itemMapped = _mapper.Map<CategoriaDTO>(result);
            return itemMapped;
        }

        [HttpGet("{nome}")]
        public async Task<CategoriaDTO> GetByNameCategoria(string nome)
        {
            var result = await _categoriaService.GetByNameCategoria(nome);
            var itemMapped = _mapper.Map<CategoriaDTO>(result);
            return itemMapped;
        }

        [HttpPost]
        public async Task<CategoriaDTO> CreateCategoria(CategoriaDTO categoriaDto)
        {
            var itemMapped = _mapper.Map<Categoria>(categoriaDto);
            var result = await _categoriaService.CreateCategoria(itemMapped);
            var resultMapped = _mapper.Map<CategoriaDTO>(result);
            return resultMapped;
        }

        [HttpPut("{id}")]
        public async Task<CategoriaDTO> UpdateCategoria(int id, CategoriaDTO categoriaDto)
        {
            var itemMapped = _mapper.Map<Categoria>(categoriaDto);
            var result = await _categoriaService.UpdateCategoria(id, itemMapped);
            var resultMapped = _mapper.Map<CategoriaDTO>(result);
            return resultMapped;
        }

        [HttpDelete("{id}")]
        public async Task DeleteCategoria(int id)
        {
            await _categoriaService.DeleteCategoria(id);
        }

    }
}
