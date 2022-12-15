using ProjetoMac.Models;

namespace ProjetoMac.ViewModels
{
    public class LanchesListViewModel
    {
        public IEnumerable<Lanche> Lanches {get; set;}
        public string CategoriaAtual { get; set;}
    }
}
