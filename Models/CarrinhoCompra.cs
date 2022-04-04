using LanchesMac.Context;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Models
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext _context;

        public CarrinhoCompra(AppDbContext context)
        {
            _context = context;
        }

        public string Id { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }
        
        public static CarrinhoCompra ObterInstancia(IServiceProvider services)
        {
            ISession session = 
                services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDbContext>();

            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            session.SetString("CarrinhoId",carrinhoId);

            return new CarrinhoCompra(context)
            {
                Id = carrinhoId
            };
        }

        public void Adicionar(Lanche lanche)
        {
            var carrinhoCompraItem = EncontrarLanche(lanche.Id);
            
            if(carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem{
                    CarrinhoCompraId=Id,
                    Lanche=lanche,
                    Quantidade=1
                };
                _context.CarrinhoCompraItens.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            };
            _context.SaveChanges();
        }

        public int Remover(Lanche lanche)
        {
            var carrinhoCompraItem = EncontrarLanche(lanche.Id);

            int quantidadeLocal=0;

            if(carrinhoCompraItem != null)
            {
                carrinhoCompraItem.Quantidade--;
                quantidadeLocal = carrinhoCompraItem.Quantidade;
            }
            else
            {
                _context.CarrinhoCompraItens.Remove(carrinhoCompraItem);
            }

            _context.SaveChanges();
            return quantidadeLocal;
        }

        public CarrinhoCompraItem EncontrarLanche(int lancheId)
        {
            return _context.CarrinhoCompraItens.SingleOrDefault(
                s=> s.Lanche.Id == lancheId && s.CarrinhoCompraId==Id);
        }

        public List<CarrinhoCompraItem> ListarItens()
        {
            return CarrinhoCompraItens ?? 
                _context.CarrinhoCompraItens
                    .Where(c=>c.CarrinhoCompraId==Id)
                    .Include(s=>s.Lanche)
                    .ToList();
        }

        public void Limpar()
        {
            var carrinhoItens = _context.CarrinhoCompraItens
                                    .Where(c=>c.CarrinhoCompraId==Id);

            if(carrinhoItens.Count() > 0)
            {
                _context.CarrinhoCompraItens.RemoveRange(carrinhoItens);
                _context.SaveChanges();
            }
        }

        public decimal ValorTotal()
        {
            return _context.CarrinhoCompraItens                        
                        .Where(c=>c.CarrinhoCompraId==Id)
                        .Select(c=>c.Lanche.Preco * c.Quantidade)
                        .Sum();            
        }
    }
}