using CarrierPidgeon.Models;

namespace CarrierPidgeon.Services
{
    public class GridServices
    {
        public Grid grid {get;} = new Grid();

        public static List<Node> InitializeNodes()
        {
            // Initialize the nodes array with default values
            int width = 10;
            int height = 10;
            return NodeServices.initNodes(width, height);
        }
    }
}