using Microsoft.AspNetCore.Mvc;
using ProjetoMac.Repositories.Interfaces;
using ProjetoMac.ViewModels;

namespace ProjetoMac.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;

        public LancheController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }
        public IActionResult List()
        {
            var lanchesListViewModel = new LanchesListViewModel();
           lanchesListViewModel.Lanches = _lancheRepository.Lanches;
           lanchesListViewModel.CategoriaAtual = "Categoria Atual";
           return View(lanchesListViewModel);
        }
    }
}
