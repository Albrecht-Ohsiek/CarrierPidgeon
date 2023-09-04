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
                do
                {
                    if (openNodes.Count == 0)
                    {
                        throw new Exception("No path found");
                    }

                    Node currentNode = getNextNode(openNodes);
                    openNodes.Remove(currentNode);
                    closedNodes.Add(currentNode);

                    if (currentNode.properties.Contains(unique_node_properties.End))
                    {
                        return currentNode.origin;
                    }

                    List<Node> neighbors = getNeighbors(nodes, currentNode);

                    foreach (Node neighbor in neighbors)
                    {
                        if (closedNodes.Contains(neighbor))
                        {
                            continue;
                        }

                        int gCost = node_services.calculateGCost(startNode, neighbor);

                        if(!openNodes.Contains(neighbor) || gCost < neighbor.gCost)
                        {
                            neighbor.gCost = gCost;
                            neighbor.hCost = node_services.calculateHCost(nodes[endNode.posX, endNode.posY], neighbor);
                            neighbor.fCost = node_services.calculateFCost(neighbor.gCost, neighbor.hCost);
                            neighbor.origin.Add(currentNode);

                            if(!openNodes.Contains(neighbor))
                            {
                                openNodes.Add(neighbor);
                            }
                        }               
                    }

                } while (true);

            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return new List<Node>();
            }
            
        }

        private static Node getNextNode(List<Node> openNodes)
        {
            try
            {
                int lowestFCost = openNodes.Min(node => node.fCost);
                List<Node> nodeLowestFCost = openNodes.Where(node => node.fCost == lowestFCost).ToList();

                if (nodeLowestFCost.Count > 1)
                {
                    int lowestGCost = nodeLowestFCost.Min(node => node.gCost);
                    List<Node> nodeLowestGCost = openNodes.Where(node => node.fCost == lowestGCost).ToList();
                    return nodeLowestGCost[0];
                }
                else
                {
                    return nodeLowestFCost[0];
                }

            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return null;
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

                    if (!neighbor.properties.Contains(node_properties.Obstacle))
                    {
                        neighbors.Add(neighbor);
                    }
                }
            }

            return neighbors;
        }



    }

}