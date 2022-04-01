using LanchesMac.Models;

namespace LanchesMac.Repositories.Interfaces
{
    public interface ILancheRepository
    {
         IEnumerable<Lanche> Lanches{get;}
         IEnumerable<Lanche> LanchesPreferidos{get;}
         public Lanche GetLancheById(int id);
    }
}