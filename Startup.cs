using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using StockOrderManagement.Data;
using StockOrderManagement.Services;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddAuthorization();
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseMySql(Configuration.GetConnectionString("dbConnection"), new MySqlServerVersion(new Version(8, 0, 28)));
        });

        services.AddScoped<IStockService, StockService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IStockRepository, StockRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        // Other services and configurations
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
        app.UseAuthentication();


        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Stock}/{action=Index}/{id?}");
        });
    }
}
