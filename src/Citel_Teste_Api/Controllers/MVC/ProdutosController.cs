using Citel_Teste_Core.Interfaces;
using Citel_Teste_Entity.Models;
using Citel_Teste_Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Citel_Teste_Api.Controllers.MVC
{
    public class ProdutosController : Controller
    {
        private readonly CitelDbContext _context;
        private IProdutoService _Produtoservice;

        public ProdutosController(CitelDbContext context, IProdutoService Produtoservice)
        {
            _context = context;
            _Produtoservice = Produtoservice;
        }


        public async Task<IActionResult> Index()
        {
            var Produtos = await _context.Produtos.ToListAsync();
            ViewBag.Produtos = Produtos;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduto(Produto Produto)
        {
            await _Produtoservice.CreateProduto(Produto);

            return RedirectToAction("Index");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduto(Produto Produto)
        {
            await _Produtoservice.UpdateProduto(Produto.Id, Produto);

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduto(int ProdutoId)
        {
            await _Produtoservice.DeleteProduto(ProdutoId);

            return RedirectToAction("Index");
        }
    }
}
