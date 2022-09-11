﻿using LancheMVC;
using LancheMVC_Aplication.Interfaces;
using LancheMVC_Aplication.Maps;
using LancheMVC_Aplication.Serviços;
using LancheMVC_Data.Contexto;
using LancheMVC_Data.Identity;
using LancheMVC_Data.Repository;
using LancheMVC_Domain.ContasInterfaces;
using LancheMVC_Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
           

      
        
            services.AddScoped<ILanches, RepositoryLanche>();
            services.AddScoped<ILancheServices, LancheService>();
            services.AddScoped<ICategoria, RepositoryCategoria>();
            services.AddScoped<ICategoryServices, CategoryService>();
            services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));// carrinho instaciado e iniciado na sessao
            services.AddScoped<IPedidoRepository, PedidoRepository>();


            services.AddAutoMapper(typeof(DomainTOMappingProfile));

            return services;
        }
    }
}