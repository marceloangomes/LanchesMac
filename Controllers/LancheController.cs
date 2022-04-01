using Microsoft.AspNetCore.Mvc;
using LanchesMac.Repositories.Interfaces;

namespace LanchesMac.Controllers
{
    public class LancheController:Controller
    {
        private readonly ILancheRepository _lancherepository;

        public LancheController(ILancheRepository lancheRepository)
        {
            _lancherepository = lancheRepository;
        }

        public IActionResult List()
        {
            var lanches = _lancherepository.Lanches;
            return View(lanches);
        }
    }
}