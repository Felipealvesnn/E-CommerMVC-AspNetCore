using LancheMV_InfraIOC;
using LancheMVC_Data.Contexto;
using LancheMVC_Domain.ContasInterfaces;
using Microsoft.AspNetCore.Identity;

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
        //services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("coneccaoDB"),
        //    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName))

        //);

        services.ConfiguraçãoServices(Configuration);

       

        services.AddIdentity<IdentityUser, IdentityRole>()

            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

     
   

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
     
      

   

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
         ISeedUserRoleInitial seedUserRoleInitial)
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

        //usado para incluir as roles e os usuarios
        seedUserRoleInitial.SeedRole();
        seedUserRoleInitial.SeedUser();

        app.UseSession();//sessão inicializada

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                   name: "areas",
                   pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
                 );

            endpoints.MapControllerRoute(
            name: "CategoriaFiltro",
            pattern: "Lanche/{action}/{Categoria?}",
            defaults: new { controller = "Lanche", Action = "List" }
            );

            endpoints.MapControllerRoute(
               name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}