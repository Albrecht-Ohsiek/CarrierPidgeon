using CarrierPidgeon.Models;
using CarrierPidgeon.Services;

namespace CarrierPidgeon.Middleware
{
    class NodeMiddleware
    {
        private List<Node> nodes;
        private NodeServices nodeServices;

        public NodeMiddleware(List<Node> nodes)
        {
            this.nodes = nodes;
            nodeServices = new NodeServices(nodes);
        }

        public static List<Node> initNodes(int x, int y)
        {
            return NodeServices.initNodes(x, y);
        }

        public void setObstacle(Node node)
        {
            nodeServices.setObstacle(node);
        }

        public void setStart(Node node)
        {
            nodeServices.setStart(node);
        }

        public void setEnd(Node node)
        {
            nodeServices.setEnd(node);
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