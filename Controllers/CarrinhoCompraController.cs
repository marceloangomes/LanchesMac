using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewsModel;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(ILancheRepository lancheRepository, CarrinhoCompra carrinhoCompra)
        {
            _lancheRepository = lancheRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index()
        {
            _carrinhoCompra.CarrinhoCompraItens = _carrinhoCompra.ListarItens();
            var carrinhoCompraItemViewModel = new CarrinhoCompraViewModel(){
                CarrinhoCompra =_carrinhoCompra,
                ValorTotal =_carrinhoCompra.ValorTotal()
            };
            return View(carrinhoCompraItemViewModel);
        }
    }
}