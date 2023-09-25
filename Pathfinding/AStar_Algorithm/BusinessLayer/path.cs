using AStart_Algorithm.Business_Layer;

namespace AStart_Algorithm
{
    class Path
    {
        public static List<Node> calculatePath(Node[,] nodes, Node startNode, Node endNode)
        {
            List<Node> openNodes = new List<Node>();
            List<Node> closedNodes = new List<Node>();

            startNode = node_services.getNodeCosts(startNode, startNode, endNode);

            openNodes.Add(nodes[startNode.posX, startNode.posY]);

            try
            {
                Node currentNode = getNextNode(openNodes);

                while (pathPossible(openNodes) || pathFound(currentNode))
                {
                    currentNode = getNextNode(openNodes);
                    openNodes.Remove(currentNode);
                    closedNodes.Add(currentNode);

                    if (currentNode.properties.Contains(UniqueNodeProperties.End))
                    {
                        return currentNode.origin!;
                    }

                    List<Node> neighbors = getNeighbors(nodes, currentNode);

                    foreach (Node neighbor in neighbors)
                    {
                        if (closedNodes.Contains(neighbor))
                        {
                            continue;
                        }

                        int gCost = node_services.calculateGCost(startNode, neighbor);

                        if (!openNodes.Contains(neighbor) || gCost < neighbor.gCost)
                        {
                            neighbor.gCost = gCost;
                            neighbor.hCost = node_services.calculateHCost(nodes[endNode.posX, endNode.posY], neighbor);
                            neighbor.fCost = node_services.calculateFCost(neighbor.gCost, neighbor.hCost);
                            neighbor.origin = currentNode.origin;
                            neighbor.origin!.Add(currentNode);

                            if (!openNodes.Contains(neighbor))
                            {
                                openNodes.Add(neighbor);
                            }
                        }
                    }

                }

            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return new List<Node>();
            }
            finally
            {
            }
            return new List<Node>();
        }

        private static bool pathFound(Node currentNode)
        {
            if (currentNode.properties.Contains(UniqueNodeProperties.End))
            {
                return true;
            }
            return false;
        }

        private static bool pathPossible(List<Node> openNodes)
        {
            if (openNodes.Count == 0)
            {
                return false;
            }
            return true;
        }

        private static Node getNextNode(List<Node> openNodes)
        {
            int lowestFCost = openNodes.Where(node => node != null).Min(node => node.fCost);
            List<Node> nodeLowestFCost = openNodes.Where(node => node != null && node.fCost == lowestFCost).ToList();

            if (nodeLowestFCost.Count > 1)
            {
                int lowestGCost = nodeLowestFCost.Where(node => node != null).Min(node => node.gCost);
                List<Node> nodeLowestGCost = nodeLowestFCost.Where(node => node != null && node.gCost == lowestGCost).ToList();
                return nodeLowestGCost.First();
            }
            else
            {
                return nodeLowestFCost.First();
            }
        }

        private static List<Node> getNeighbors(Node[,] nodes, Node currentNode)
        {
            List<Node> neighbors = new List<Node>();
            int gridLength = nodes.GetLength(0);
            int gridBreadth = nodes.GetLength(1);

            // Define the possible relative positions of neighbors
            int[] dx = { -1, 0, 1, -1, 1, -1, 0, 1 };
            int[] dy = { -1, -1, -1, 0, 0, 1, 1, 1 };

            for (int i = 0; i < 8; i++)
            {
                int newX = currentNode.posX + dx[i];
                int newY = currentNode.posY + dy[i];

                if (newX >= 0 && newX < gridLength && newY >= 0 && newY < gridBreadth)
                {
                    Node neighbor = nodes[newX, newY];

                    if (!neighbor.properties.Contains(NodeProperties.Obstacle))
                    {
                        neighbors.Add(neighbor);
                    }
                }
            }

            return neighbors;
        }

    }

}