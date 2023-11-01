using CarrierPidgeon.Services;
using CarrierPidgeon.Models;
using CarrierPidgeon.Middleware;
using CarrierPidgeon.Serializer;
using CarrierPidgeon.Repositories;
using CarrierPidgeon.Keys;
using MongoDB.Bson.Serialization;
namespace CarrierPidgeon.Config;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        BsonSerializer.RegisterSerializer(new PointSerializer());

        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "Properties"))
            .AddJsonFile("appSettings.json")
            .Build();
        services.AddSingleton(configuration);

        AuthenticationConfiguration authenticationConfiguration = new AuthenticationConfiguration();
        GridConfiguration gridConfiguration = new GridConfiguration();
        
        configuration.Bind("JwtAuth", authenticationConfiguration);
        configuration.Bind("Grid", gridConfiguration); 
        services.AddSingleton(authenticationConfiguration);
        services.AddSingleton(gridConfiguration);

        services.AddScoped<GridServices>();
        services.AddScoped<DroneServices>();
        services.AddScoped<AuthenticationServices>();

        GridMiddleware gridMiddleware = new GridMiddleware(gridConfiguration);
        List<Node> nodes = gridMiddleware.InitializeGrid();
        services.AddSingleton(nodes);

        NodeMiddleware nodeMiddleware = new NodeMiddleware(nodes);
        nodeMiddleware.setStart(gridConfiguration.start);

        services.AddSingleton<Keygen>();
        services.AddSingleton<DatabaseServices>();

        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddTransient<IRouteRepository, RouteRepository>();
        services.AddTransient<DroneRepository>();
        services.AddTransient<RouteService>();

        services.AddControllers();

        services.AddCors(options =>
        {
            options.AddPolicy("MyCorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
        });

        // Add your other services here

        var authenticationServices = services.BuildServiceProvider().GetService<AuthenticationServices>();
        authenticationServices.ConfigureAuthentication(services);

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
    {
        RouteConfig.Configure(app, environment);

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseCors("MyCorsPolicy");

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "dashboard",
                pattern: "dashboard/{action}",
                defaults: new { controller = "DashboardController" }
            );

            endpoints.MapControllerRoute(
                name: "drone",
                pattern: "drone/{action}",
                defaults: new { controller = "DroneController" }
            );

            endpoints.MapControllerRoute(
                name: "api",
                pattern: "api/{controller}/{action}/{id?}"
            );

            // Add other endpoint mappings here


        });

        // Add other middleware and configurations here
    }

}