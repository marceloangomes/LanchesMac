using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewsModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    [Authorize]
    public class CarrinhoCompraController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(ILancheRepository lancheRepository, CarrinhoCompra carrinhoCompra)
        {
            _lancheRepository = lancheRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            _carrinhoCompra.CarrinhoCompraItens = _carrinhoCompra.ListarItens();
            var carrinhoCompraViewModel = new CarrinhoCompraViewModel(_carrinhoCompra)
            {                
                ValorTotal =_carrinhoCompra.ValorTotal()
            };
            return View(carrinhoCompraViewModel);
        }

        public RedirectToActionResult Adicionar(int lancheId)
        {
            var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(l=>l.Id==lancheId);
            if(lancheSelecionado!=null)
            {
                _carrinhoCompra.Adicionar(lancheSelecionado);
            }

            return RedirectToAction("index");
        }

        public IActionResult Remover(int lancheId)
        {
            var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(l=>l.Id==lancheId);
            if(lancheSelecionado!=null)
            {
                _carrinhoCompra.Remover(lancheSelecionado);
            }
            return RedirectToAction("index");
        }
    }
}