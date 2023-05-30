using AutoMapper;
using Citel_Teste_Api.Dto;
using Citel_Teste_Core.Interfaces;
using Citel_Teste_Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace Citel_Teste_Api.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;
        public ProdutosController(IProdutoService produtoService, IMapper mapper)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProdutoDTO>> GetAllProdutos()
        {
            var result = await _produtoService.GetAllProduto();
            var listaProdutoDto = new List<ProdutoDTO>();
            foreach (var item in result)
            {
                var itemMapped = _mapper.Map<ProdutoDTO>(item);
                listaProdutoDto.Add(itemMapped);
            }
            return listaProdutoDto;
        }

        [HttpGet("id/{id}")]
        public async Task<ProdutoDTO> GetByIdProduto(int id)
        {
            var result = await _produtoService.GetByIdProduto(id);
            var itemMapped = _mapper.Map<ProdutoDTO>(result);
            return itemMapped;
        }

        [HttpGet("categoriaId/{categoriaId}")]
        public async Task<IEnumerable<ProdutoDTO>> GetByCategoriaIdProduto(int categoriaId)
        {
            var result = await _produtoService.GetByCategoriaIdProduto(categoriaId);
            var listaProdutoDto = new List<ProdutoDTO>();
            foreach (var item in result)
            {
                var itemMapped = _mapper.Map<ProdutoDTO>(item);
                listaProdutoDto.Add(itemMapped);
            }
            return listaProdutoDto;
        }

        [HttpGet("{nome}")]
        public async Task<ProdutoDTO> GetByNameProduto(string nome)
        {
            var result = await _produtoService.GetByNameProduto(nome);
            var itemMapped = _mapper.Map<ProdutoDTO>(result);
            return itemMapped;
        }

        [HttpPost]
        public async Task<ProdutoDTO> CreateProduto(ProdutoDTO ProdutoDto)
        {
            var itemMapped = _mapper.Map<Produto>(ProdutoDto);
            var result = await _produtoService.CreateProduto(itemMapped);
            var resultMapped = _mapper.Map<ProdutoDTO>(result);
            return resultMapped;
        }

        [HttpPut("{id}")]
        public async Task<ProdutoDTO> UpdateProduto(int id, ProdutoDTO ProdutoDto)
        {
            var itemMapped = _mapper.Map<Produto>(ProdutoDto);
            var result = await _produtoService.UpdateProduto(id, itemMapped);
            var resultMapped = _mapper.Map<ProdutoDTO>(result);
            return resultMapped;
        }

        [HttpDelete("{id}")]
        public async Task DeleteProduto(int id)
        {
            await _produtoService.DeleteProduto(id);
        }

    }
}
