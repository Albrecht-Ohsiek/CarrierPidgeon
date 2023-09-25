namespace CarrierPidgeon
{
    public class Drone_Routes
    {
        public static void getDroneEndpoints(WebApplication webApplication)
        {
            webApplication.MapGet("/drone/{droneId}/getRoute", async (string droneId) =>
            {
                // Return Node.origin for specific drone

                return "Fuck you " + droneId;
            });

            webApplication.MapPost("/drone/{droneId}/setObstacle", async (string droneId) =>
            {

            });

            webApplication.MapPost("/drone/{droneId}/setComplete", async (string droneId) => 
            {

            });       

        }
    }
}