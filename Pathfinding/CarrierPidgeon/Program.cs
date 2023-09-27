using CarrierPidgeon.Services;

namespace CarrierPidgeon
{
    class Program
    {
        static void Main(string[] args)
        {
            WebApplicationBuilder webApplicationBuilder = WebApplication.CreateBuilder(args);

            webApplicationBuilder.Services.AddControllers();
            webApplicationBuilder.Services.AddScoped<Grid_Services>();

            WebApplication webApplication = webApplicationBuilder.Build();

            if (webApplication.Environment.IsDevelopment())
            {
                webApplication.UseDeveloperExceptionPage();
            }
            else
            {
                // Configure production settings
            }

            webApplication.UseRouting();

            // Use top-level route registrations directly in Program.cs
            webApplication.MapControllerRoute(
                name: "dashboard",
                pattern: "dashboard/{action}",
                defaults: new { controller = "Dashboard" }
            );

            // webApplication.Run("https://localhost:4000");
            webApplication.Run();
        }
    }
}
