using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class PedidoController : Controller
    {

        private readonly IPedidoRepository _pedidoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoController(IPedidoRepository pedidoRepository, CarrinhoCompra carrinhoCompra)
        {
            _pedidoRepository = pedidoRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Checkout(Pedido pedido)
        {
            int totalItensPedido = 0;
            decimal precoTotalPedido = 0.0m;
            List<CarrinhoCompraItem> itens = _carrinhoCompra.ListarItens();
            _carrinhoCompra.CarrinhoCompraItens = itens;

            if(_carrinhoCompra.CarrinhoCompraItens.Count == 0)
            {
                ModelState.AddModelError("","Seu carrinho está vázio que tal incluir um lanche...");
            }
            
            foreach (var item in itens)
            {
                totalItensPedido+=item.Quantidade;
                precoTotalPedido+=item.Quantidade * item.Lanche.Preco;
            }

            pedido.PedidoTotal=precoTotalPedido;
            pedido.TotalItensPedido=totalItensPedido;

            if(ModelState.IsValid)
            {
                _pedidoRepository.CriarPedido(pedido);
                ViewBag.CheckoutCompletoMensagem = "Obrigado pelo seu pedido.";
                ViewBag.TotalPedido = _carrinhoCompra.ValorTotal();

                _carrinhoCompra.Limpar();

                return View("~/Views/Pedido/CheckOutCompleto.cshtml",pedido);
            }
            
            return View(pedido);
        }
    }
}