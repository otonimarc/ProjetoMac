using ProjetoMac.Context;
using Microsoft.EntityFrameworkCore;
using ProjetoMac.Models;
using ProjetoMac.Repositories;
using ProjetoMac.Repositories.Interfaces;

namespace ProjetoMac;
public class Startup
    {
     public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        services.AddTransient<ILancheRepository, LancheRepository>();
        services.AddTransient<IPedidoRepository, PedidoRepository>();
        services.AddTransient<ICategoriaRepository, CategoriaRepository>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddControllersWithViews();
        services.AddMemoryCache();
        services.AddSession();
        services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseSession();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "categoriaFiltro",
                pattern: "Lanche/{action}/{categoria?}",
                defaults: new { Controller = "Lanche", action = "List" });


            endpoints.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{id?}"); 
       });
    }
 }

