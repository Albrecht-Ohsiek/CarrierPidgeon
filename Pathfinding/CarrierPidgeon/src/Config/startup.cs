using CarrierPidgeon.Services;
using CarrierPidgeon.Handlers;
using CarrierPidgeon.Models;

namespace CarrierPidgeon.Config;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddScoped<Grid_Services>();
        services.AddScoped<Drone_Services>();
        services.AddScoped<DashboardHandler>();

        // Add your other services here

        Node[,] nodes = node_services.InitializeNodes();
        services.AddSingleton<Node[,]>(nodes);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
    {
        RouteConfig.Configure(app, environment);

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "dashboard",
                pattern: "dashboard/{action}",
                defaults: new { controller = "Dashboard_Controller" }
            );

            endpoints.MapControllerRoute(
                name: "drone",
                pattern: "drone/{action}",
                defaults: new { controller = "Drone_Controller" }
            );

            // Add other endpoint mappings here
        });

        // Add other middleware and configurations here
    }

}