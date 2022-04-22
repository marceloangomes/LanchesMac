using LanchesMac.Context;
using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;

namespace LanchesMac.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoRepository(AppDbContext appDbContext, CarrinhoCompra carrinhoCompra)
        {
            _appDbContext = appDbContext;
            _carrinhoCompra = carrinhoCompra;
        }

        public void CriarPedido(Pedido pedido)
        {
            pedido.PedidoEnviado=DateTime.Now;
            _appDbContext.Pedido.Add(pedido);
            _appDbContext.SaveChanges();

            var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItens;

            foreach (var item in carrinhoCompraItens)
            {
                var pedidoDetalhe = new PedidoDetalhe()
                {
                    Quantidade=item.Quantidade,
                    LancheId=item.Lanche.Id,
                    PedidoId=pedido.Id,
                    Preco=item.Lanche.Preco
                };
                _appDbContext.PedidoDetalhes.Add(pedidoDetalhe);                
            }
            _appDbContext.SaveChanges();
        }
    }
}