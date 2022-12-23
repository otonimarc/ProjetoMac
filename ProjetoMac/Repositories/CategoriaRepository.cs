using ProjetoMac.Context;
using ProjetoMac.Models;

namespace ProjetoMac.Repositories.Interfaces
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoriaRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

        public IEnumerable<Categoria> Categorias => _appDbContext.Categorias;
    }
}
