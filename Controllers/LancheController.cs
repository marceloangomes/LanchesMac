using Microsoft.AspNetCore.Mvc;
using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewsModel;
using LanchesMac.Models;

namespace LanchesMac.Controllers
{
    public class LancheController:Controller
    {
        private readonly ILancheRepository _lancheRepository;       

        public LancheController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;            
        }

        public IActionResult List(String categoria)
        {
            IEnumerable<Lanche> lanches;
            Categoria categoriaAtual = null;
            if(string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l=>l.Id);
                categoriaAtual = new Categoria {Id=0, Nome="Todos os Lanches"};
            }
            else
            {                
                lanches = _lancheRepository.Lanches
                    .Where(l=>l.Categoria.Nome.Equals(categoria, StringComparison.OrdinalIgnoreCase))
                    .OrderBy(l=>l.Nome);     
                categoriaAtual = lanches.FirstOrDefault().Categoria;                                          
            }

            var lancheListViewModel = new LancheListViewModel
            {
                Lanches=lanches,
                CategoriaAtual = categoriaAtual
            };

            return View (lancheListViewModel);
        }

        public IActionResult Details(int Id)
        {
            var lanche = _lancheRepository.GetLancheById(Id);
            return View(lanche);
        }

        public ViewResult Search(string searchString)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual =string.Empty;

            if(string.IsNullOrEmpty(searchString))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.Id);
                categoriaAtual="Todos os lanches";                
            }
            else
            {
                lanches=_lancheRepository.Lanches
                    .Where(l=>l.Nome.ToLower().Contains(searchString.ToLower()));

                if(lanches.Any())
                {
                    categoriaAtual="Lanches";
                }
                else
                {
                    categoriaAtual="Nenhum Lanche foi encontrado";
                }
            }

            return View("~/Views/Lanche/List.cshtml", new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = new Categoria{Id=0,Nome=categoriaAtual}
            });
        }
    }
}