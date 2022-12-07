using FastReport.Data;
using LancheMVC;
using LancheMVC_Aplication.Interfaces;
using LancheMVC_Aplication.Maps;
using LancheMVC_Aplication.Serviços;
using LancheMVC_Data;
using LancheMVC_Data.Contexto;
using LancheMVC_Data.Identity;
using LancheMVC_Data.Repository;
using LancheMVC_Data.Services;
using LancheMVC_Domain;
using LancheMVC_Domain.ContasInterfaces;
using LancheMVC_Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReflectionIT.Mvc.Paging;

namespace LancheMV_InfraIOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfiguraçãoServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Method intentionally left empty.

            services.AddDbContext<AppDbContext>(options =>
            {
                options.EnableSensitiveDataLogging();
                options.UseSqlServer(configuration.GetConnectionString("coneccaoDB"),
                    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            //services.Configure<IdentityOptions>(options =>
            //{
            //    // Default Password settings.
            //    options.Password.RequireDigit = false;
            //    options.Password.RequireLowercase = false;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireUppercase = false;
            //    options.Password.RequiredLength = 3;
            //    options.Password.RequiredUniqueChars = 1;
            //});


            services.AddMemoryCache();

            services.AddControllersWithViews();
            services.AddMemoryCache();
            services.AddSession();

            services.AddScoped<ILanches, RepositoryLanche>();
            services.AddScoped<ILancheServices, LancheService>();
            services.AddScoped<ICategoria, RepositoryCategoria>();
            services.AddScoped<ICategoryServices, CategoryService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
             
            //fastreport
            FastReport.Utils.RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));
            services.AddScoped<RelatorioLanchesService>();
            

            // iniciano identity no banco
            services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            services.AddScoped<RelatorioVendaService>();
            services.AddScoped<GraficoVendasServices>();

            services.Configure<ConfigurationImagens>(configuration.GetSection("ConfigurationsPastaImagens"));

            services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp)); // carrinho instaciado e iniciado na sessao

            services.AddPaging(options =>
            {
                options.ViewName = "Bootstrap4";
                options.PageParameterName = "pageindex";
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin",
                    politica =>
                    {
                        politica.RequireRole("Admin");
                    });
            });

            services.AddAutoMapper(typeof(DomainTOMappingProfile));

            return services;
        }
    }
}