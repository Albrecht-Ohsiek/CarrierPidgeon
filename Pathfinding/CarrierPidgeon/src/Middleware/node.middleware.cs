using System.Drawing;
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

        public int GetDistance(Point point1, Point point2)
        {
            return NodeServices.getDistance(point1, point2);
        }

        public void setObstacle(Point node)
        {
            nodeServices.setObstacle(node);
        }

        public void setStart(Point node)
        {
            nodeServices.setStart(node);
        }

        public void setEnd(Point node)
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