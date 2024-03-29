﻿using LancheMV_InfraIOC;
using LancheMVC_Domain.ContasInterfaces;

var builder = WebApplication.CreateBuilder(args);



//var connection = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<AppDbContext>(options =>
//           options.UseSqlServer(connection));


//builder.Services.Configure<ConfigurationImagens>(builder.Configuration
//    .GetSection("ConfigurationPastaImagens"));

//builder.Services.AddTransient<ILancheRepository, LancheRepository>();
//builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
//builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();
//builder.Services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
//builder.Services.AddScoped<RelatorioVendasService>();
//builder.Services.AddScoped<GraficoVendasService>();

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("Admin",
//        politica =>
//        {
//            politica.RequireRole("Admin");
//        });
//});

//builder.Services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));

//builder.Services.AddControllersWithViews();

//builder.Services.AddPaging(options =>
//{
//    options.ViewName = "Bootstrap4";
//    options.PageParameterName = "pageindex";
//});

//builder.Services.AddMemoryCache();
//builder.Services.AddSession();


builder.Services.ConfiguraçãoServices(builder.Configuration);

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(5);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
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
app.UseFastReport(); //midle do fast report
app.UseRouting();

CriarPerfisUsuarios(app);

////cria os perfis
//seedUserRoleInitial.SeedRoles();
////cria os usuários e atribui ao perfil
//seedUserRoleInitial.SeedUsers();

app.UseSession();


app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
     name: "areas",
     pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
       name: "categoriaFiltro",
       pattern: "Lanche/{action}/{categoria?}",
       defaults: new { Controller = "Lanche", action = "List" });

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
}); 

app.Run();

void CriarPerfisUsuarios(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<ISeedUserRoleInitial>();
        service.SeedRole();
        service.SeedUser();
     
    }
}