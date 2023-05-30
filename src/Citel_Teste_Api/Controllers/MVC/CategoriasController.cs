using Citel_Teste_Core.Interfaces;
using Citel_Teste_Entity.Models;
using Citel_Teste_Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Citel_Teste_Api.Controllers.MVC
{
    public class CategoriasController : Controller
    {
        private readonly CitelDbContext _context;
        private ICategoriaService _categoriaService;

        public CategoriasController(CitelDbContext context, ICategoriaService categoriaService)
        {
            _context = context;
            _categoriaService = categoriaService;
        }


        public async Task<IActionResult> Index()
        {
            var categorias = await _context.Categorias.ToListAsync();
            ViewBag.Categorias = categorias;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoria(Categoria categoria)
        {
            await _categoriaService.CreateCategoria(categoria);

            return RedirectToAction("Index");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategoria(Categoria categoria)
        {
            await _categoriaService.UpdateCategoria(categoria.Id, categoria);

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategoria(int categoriaId)
        {
            await _categoriaService.DeleteCategoria(categoriaId);

            return RedirectToAction("Index");
        }
    }
}
