using System.Net;
using System.Net.Sockets;
using AStart_Algorithm;
using Microsoft.AspNetCore.Builder;

namespace AStart_Algorithm
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
