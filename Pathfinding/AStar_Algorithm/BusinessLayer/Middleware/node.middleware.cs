namespace AStart_Algorithm
{
    class Node_Middleware
    {
        public static Node[,] initNodes(int x, int y)
        {
            return node_services.initNodes(x, y);
        }

        public static Node placeObstacle(Node node)
        {
            return node_services.placeObstacle(node);
        }

        public static Node setStart(Node[,] nodes, Node node)
        {
            return node_services.setStart(nodes, node);
        }

        public static Node setEnd(Node[,] nodes, Node node)
        {
            return node_services.setEnd(nodes, node);
        }

    }
}