using LancheMVC_Aplication.Interfaces;
using LancheMVC_Aplication.Maps;
using LancheMVC_Aplication.Serviços;
using LancheMVC_Data.Contexto;
using LancheMVC_Data.Repository;
using LancheMVC_Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LancheMVC;
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("coneccaoDB"),
            b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
        services.AddControllersWithViews();
        services.AddMemoryCache();
        services.AddSession();


        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddTransient<ILanches, RepositoryLanche>();
        services.AddTransient<ILancheServices, LancheService>();
        services.AddTransient<ICategoria, RepositoryCategoria>();
        services.AddTransient<ICategoryServices, CategoryService>();

        services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));// carrinho instaciado e iniciado na sessao
        services.AddAutoMapper(typeof(DomainTOMappingProfile));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseSession();//sessão inicializada

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
           


            endpoints.MapControllerRoute(
            name: "CategoriaFiltro",
            pattern: "Lanche/{action}/{Categoria?}",
            defaults: new { controller = "Lanche", Action="List" }
            );

            endpoints.MapControllerRoute(
               name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}");



        });
    }
}