using CarrierPidgeon.Models;
using CarrierPidgeon.Services;

namespace CarrierPidgeon.Middleware
{
    class NodeMiddleware
    {
        public static Node[,] initNodes(int x, int y)
        {
            return nodeServices.initNodes(x, y);
        }

        public static Node placeObstacle(Node node)
        {
            return nodeServices.placeObstacle(node);
        }

        public static Node setStart(Node[,] nodes, Node node)
        {
            return nodeServices.setStart(nodes, node);
        }

        public static Node setEnd(Node[,] nodes, Node node)
        {
            return nodeServices.setEnd(nodes, node);
        }

    }
}