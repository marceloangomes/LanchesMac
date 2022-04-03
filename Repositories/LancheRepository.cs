using LanchesMac.Context;
using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Repositories
{   
    public class LancheRepository: ILancheRepository
    {
        private readonly AppDbContext _context;

        public LancheRepository()
        {
        }

        public LancheRepository(AppDbContext context){
            _context = context;
        }

        IEnumerable<Lanche> ILancheRepository.Lanches => _context.Lanches.Include(c=>c.Categoria);

        IEnumerable<Lanche> ILancheRepository.LanchesPreferidos => _context.Lanches
            .Where(p=>p.LanchePreferido)
            .Include(c=>c.Categoria);

        public Lanche GetLancheById(int id) => _context.Lanches.FirstOrDefault(l => l.Id == id);


    }
}