using LanchesMac.Models;

namespace LanchesMac.ViewsModel
{
    public class LancheListViewModel
    {
        public IEnumerable<Lanche> Lanches {get;set;}
        public Categoria CategoriaAtual {get;set;}

    }
}