using LanchesMac.Models;

namespace LanchesMac.ViewsModel
{
    public class CarrinhoCompraViewModel
    {
        public CarrinhoCompraViewModel(CarrinhoCompra carrinhoCompra)
        {
            this.CarrinhoCompra = carrinhoCompra;
            this.CarrinhoCompraItensViewModel = new List<CarrinhoCompraItemViewModel>();            
            foreach (var item in carrinhoCompra.CarrinhoCompraItens)
            {
                if(item.CarrinhoCompraId != null)
                {
                    this.CarrinhoCompraItensViewModel.Add(new CarrinhoCompraItemViewModel(){
                        CarrinhoCompraId=item.CarrinhoCompraId,
                        Id=item.Id,
                        Quantidade=item.Quantidade,
                        Lanche=item.Lanche,
                        ValorTotal=item.Quantidade * item.Lanche.Preco
                    });
                }
            }
        }
        public CarrinhoCompra CarrinhoCompra { get; set; }
        public List<CarrinhoCompraItemViewModel> CarrinhoCompraItensViewModel { get; set; }

        public decimal ValorTotal { get; set; }
    }
}