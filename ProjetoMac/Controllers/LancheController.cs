﻿using Microsoft.AspNetCore.Mvc;
using ProjetoMac.Models;
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

        public IActionResult List(string categoria)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
                categoriaAtual = "Todos os lanches";
            }
            else
            {
                //if (string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase))
                //{
                //    lanches = _lancheRepository.Lanches
                //        .Where(l =>   l.Categoria.CategoriaNome == "Normal")
                //        .OrderBy(l => l.Nome);
                //}
                //else
                //{
                //    lanches = _lancheRepository.Lanches
                //        .Where(l =>  l.Categoria.CategoriaNome == "Natural")
                //        .OrderBy(l => l.Nome);
                //}

                lanches = _lancheRepository.Lanches
                    .Where(l => l.Categoria.CategoriaNome == categoria)
                    .OrderBy(c => c.Nome);
                categoriaAtual = categoria;
            }

            var lanchesListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };

            return View(lanchesListViewModel);
        }

        public IActionResult Details(int lancheId)
        {
            var lanches = _lancheRepository.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
            return View(lanches);
        }

        public ViewResult Search(string searchString)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                lanches = _lancheRepository.Lanches.OrderBy(p => p.LancheId);
                categoriaAtual = "Todos os Lanches";
            }
            else
            {
                lanches = _lancheRepository.Lanches
                    .Where(p => p.Nome.ToLower().Contains(searchString.ToLower()));

                if (lanches.Any())
                    categoriaAtual = "Lanches";
                else
                    categoriaAtual = "Nenhum lanche foi encontrado";
            }
             return View("~/Views/Lanche/List.cshtml", new LancheListViewModel
             {
                 Lanches = lanches,
                 CategoriaAtual = categoriaAtual
             });
        }
    }
}
