using CarrierPidgeon.Models;
using CarrierPidgeon.Services;
using CarrierPidgeon.Middleware;
using System.Drawing;

namespace CarrierPidgeon.Algorithms
{
    class AStarAlgorithm
    {
        public static List<Point> calculatePath(List<Node> nodes, Node startNode, Point endNode)
        {
            List<Node> clearNodes = nodes.Select(n => NodeMiddleware.CloneNode(n)).ToList();

            List<Node> openNodes = new List<Node>();
            List<Node> closedNodes = new List<Node>();

            startNode = NodeServices.getNodeCosts(startNode, startNode.cords, endNode, nodes);

            openNodes.Add(nodes.FirstOrDefault(n => n.cords.X == startNode.cords.X && n.cords.Y == startNode.cords.Y));

            try
            {
                Node currentNode = getNextNode(openNodes);

                while (pathPossible(openNodes) || pathFound(currentNode))
                {
                    currentNode = getNextNode(openNodes);
                    openNodes.Remove(currentNode);
                    closedNodes.Add(currentNode);

                    if (currentNode.properties.Contains("end"))
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

                        int gCost = NodeServices.calculateGCost(startNode.cords, neighbor, nodes);

                        if (!openNodes.Contains(neighbor) || gCost < neighbor.gCost)
                        {
                            neighbor.gCost = gCost;
                            neighbor.hCost = NodeServices.calculateHCost(endNode, neighbor.cords);
                            neighbor.fCost = NodeServices.calculateFCost(neighbor.gCost, neighbor.hCost);
                            neighbor.origin = currentNode.origin;
                            neighbor.origin!.Add(currentNode.cords);

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
                return new List<Point>();
            }
            finally
            {
                nodes.Clear();
                nodes.AddRange(clearNodes);
            }
            return new List<Point>();
        }

        private static bool pathFound(Node currentNode)
        {
            if (currentNode.properties.Contains("end"))
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

        private static List<Node> getNeighbors(List<Node> nodes, Node currentNode)
        {
            List<Node> neighbors = new List<Node>();

            // Define the possible relative positions of neighbors
            int[] dx = { -1, 0, 1, -1, 1, -1, 0, 1 };
            int[] dy = { -1, -1, -1, 0, 0, 1, 1, 1 };

            foreach (int i in Enumerable.Range(0, 8))
            {
                int newX = currentNode.cords.X + dx[i];
                int newY = currentNode.cords.Y + dy[i];

                Node neighbor = nodes.FirstOrDefault(n => n.cords.X == newX && n.cords.Y == newY);

                if (neighbor != null && !neighbor.properties.Contains("obstacle"))
                {
                    neighbors.Add(neighbor);
                }
            }

            return neighbors;
        }

    }

}