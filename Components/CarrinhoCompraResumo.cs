using LanchesMac.Models;
using LanchesMac.ViewsModel;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Components
{
    public class CarrinhoCompraResumo:ViewComponent
    {
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra)
        {
            _carrinhoCompra = carrinhoCompra;
        }

        public IViewComponentResult Invoke()
        {
            _carrinhoCompra.CarrinhoCompraItens = _carrinhoCompra.ListarItens();
            // _carrinhoCompra.CarrinhoCompraItens = new List<CarrinhoCompraItem>()
            // {
            //     new CarrinhoCompraItem(),
            //     new CarrinhoCompraItem()
            // };
            
            var carrinhoCompraViewModel = new CarrinhoCompraViewModel(_carrinhoCompra)
            {                
                ValorTotal =_carrinhoCompra.ValorTotal()
            };
            return View(carrinhoCompraViewModel);
        }
    }
}