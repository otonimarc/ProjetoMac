﻿
using Microsoft.EntityFrameworkCore;
using ProjetoMac.Context;
using ProjetoMac.Models;

namespace ProjetoMac.Areas.Admin.Servicos;

public class RelatorioLanchesService
{
    private readonly AppDbContext _context;

    public RelatorioLanchesService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Lanche>> GetLanchesReport()
    {
        var lanches = await _context.Lanches.ToListAsync();

        if(lanches is null)
            return default(IEnumerable<Lanche>);

        return lanches;
    }

    public async Task<IEnumerable<Categoria>> GetCategoriasReport()
    {
        var categorias = await _context.Categorias.ToListAsync();

        if (categorias is null)
            return default(IEnumerable<Categoria>);

        return categorias;
    }
}