namespace CarrierPidgeon.Config;

public class RouteConfig
{
    public static void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
    {
        ConfigureEnvironment(app, environment);
    }

    public static void ConfigureEnvironment(IApplicationBuilder app, IWebHostEnvironment environment)
    {
        app.UseRouting();

        if (environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            // Configure production settings
        }
    }
}