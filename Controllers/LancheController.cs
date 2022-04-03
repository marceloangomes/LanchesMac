using Microsoft.AspNetCore.Mvc;
using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewsModel;

namespace LanchesMac.Controllers
{
    public class LancheController:Controller
    {
        private readonly ILancheRepository _lancheRepository;

        public LancheController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult List()
        {
            //var lanches = _lancherepository.Lanches;
            ViewData["Title"] = "Todos os Lanches";
            //return View(lanches);
            var lancheListViewModel = new LancheListViewModel();
            lancheListViewModel.Lanches = _lancheRepository.Lanches;
            Models.Categoria categoria = new Models.Categoria();
            categoria.Id=1;
            categoria.Nome="Qualquer";
            lancheListViewModel.CategoriaAtual = categoria;
            return View(lancheListViewModel);
        }
    }
}