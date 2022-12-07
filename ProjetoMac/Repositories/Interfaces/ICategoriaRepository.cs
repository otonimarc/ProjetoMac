using ProjetoMac.Models;

namespace ProjetoMac.Repositories.Interfaces
{
    public interface ICategoriaRepository 
    {
        IEnumerable<Categoria> Categorias { get; }

    }
}