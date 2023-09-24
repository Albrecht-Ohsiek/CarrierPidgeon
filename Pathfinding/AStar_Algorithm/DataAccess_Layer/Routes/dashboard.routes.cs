namespace AStart_Algorithm
{
    public class Dashboard_Routes
    {
        public static void getDroneEndpoints(WebApplication webApplication)
        {
            webApplication.MapGet("/dashboard/{droneId}", async (string droneId) =>
            {
                // Return Node.origin for specific drone

                return "Fuck you " + droneId;
            });

        }
    }
}