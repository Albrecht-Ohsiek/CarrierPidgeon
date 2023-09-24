namespace AStart_Algorithm
{
    public class Dashboard_Routes
    {
        public static void getDroneEndpoints(WebApplication webApplication)
        {
            webApplication.MapGet("/dashboard/", async () =>
            {
                // Return Node.origin for specific drone

                return "Dashboard ";
            });

        }
    }
}