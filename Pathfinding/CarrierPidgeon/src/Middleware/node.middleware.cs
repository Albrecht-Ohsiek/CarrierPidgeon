using CarrierPidgeon.Models;
using CarrierPidgeon.Services;

namespace CarrierPidgeon.Middleware
{
    class NodeMiddleware
    {
        public static Node[,] initNodes(int x, int y)
        {
            return NodeServices.initNodes(x, y);
        }

        public static Node placeObstacle(Node node)
        {
            return NodeServices.placeObstacle(node);
        }

        public static Node setStart(Node[,] nodes, Node node)
        {
            return NodeServices.setStart(nodes, node);
        }

        public static Node setEnd(Node[,] nodes, Node node)
        {
            return NodeServices.setEnd(nodes, node);
        }

    }
}