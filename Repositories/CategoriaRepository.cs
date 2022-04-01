using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using LanchesMac.Context;

namespace LanchesMac.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        IEnumerable<Categoria> ICategoriaRepository.Categorias => _context.Categorias;
    }
}