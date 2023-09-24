namespace AStart_Algorithm
{
    public class Api_Endpoints
    {
        public static void getEnpoints(WebApplication webApplication)
        {
            Drone_Routes.getDroneEndpoints(webApplication);
            Dashboard_Routes.getDroneEndpoints(webApplication);
        }
    }
}