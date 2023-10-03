using CarrierPidgeon.Models;
using CarrierPidgeon.Services;

namespace CarrierPidgeon.Middleware
{
    class NodeMiddleware
    {
        public static List<Node> initNodes(int x, int y)
        {
            return NodeServices.initNodes(x, y);
        }

        public static Node setObstacle(List<Node> nodes, Node node)
        {
            return NodeServices.setObstacle(nodes, node);
        }

        public static Node setStart(List<Node> nodes, Node node)
        {
            return NodeServices.setStart(nodes, node);
        }

        public static Node setEnd(List<Node> nodes, Node node)
        {
            return NodeServices.setEnd(nodes, node);
        }

        public static Node getNodeCosts(Node currentNode, Node startNode, Node endNode)
        {
            return NodeServices.getNodeCosts(currentNode, startNode, endNode);
        }

    }
}