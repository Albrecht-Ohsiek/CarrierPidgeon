namespace CarrierPidgeon
{
    class Program
    {
        static void Main(string[] args)
        {
            WebApplicationBuilder webApplicationBuilder = WebApplication.CreateBuilder(args);

            WebApplication webApplication = webApplicationBuilder.Build();

            Api_Endpoints.getEnpoints(webApplication);

            webApplication.Run();
        }
    }
}
