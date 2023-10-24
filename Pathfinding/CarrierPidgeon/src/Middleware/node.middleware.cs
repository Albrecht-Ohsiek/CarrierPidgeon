using CarrierPidgeon.Models;
using CarrierPidgeon.Services;

namespace CarrierPidgeon.Middleware
{
    class NodeMiddleware
    {
        private List<Node> nodes;

        public NodeMiddleware(List<Node> nodes)
        {
            this.nodes = nodes;
        }

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

        public static Node getNodeCosts(Node currentNode, Node startNode, Node endNode, List<Node> nodes)
        {
            return NodeServices.getNodeCosts(currentNode, startNode.cords, endNode.cords, nodes);
        }

        public static Node CloneNode(Node node)
        {
            return NodeServices.CloneNode(node);
        }

    }
}