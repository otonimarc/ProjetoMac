using Microsoft.EntityFrameworkCore;
using ProjetoMac.Context;
using ProjetoMac.Models;
using ProjetoMac.Repositories.Interfaces;

namespace ProjetoMac.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext _context;
        public LancheRepository(AppDbContext contexto)
        {
            _context = contexto;
        }
        public IEnumerable<Lanche> Lanches => _context.Lanches;
          public  IEnumerable<Lanche> LanchesPreferidos =>  _context.Lanches.
                                                             Where(l=> l.IsLanchePreferido)
                                                            .Include(c => c.Categoria);
        public Lanche GetLancheById(int lancheid)
        {
            return _context.Lanches.FirstOrDefault(l => l.LancheId == lancheid); 
        }
    }
}
