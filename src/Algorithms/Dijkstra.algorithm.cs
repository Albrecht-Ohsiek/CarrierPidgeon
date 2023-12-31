using System.Drawing;
using CarrierPidgeon.Middleware;
using CarrierPidgeon.Models;

namespace CarrierPidgeon.Algorithms
{
    public class Dijkstra
    {

        private readonly List<Node> nodes;
        private NodeMiddleware nodeMiddleware;

        public Dijkstra(List<Node> nodes)
        {
            this.nodes = nodes;
            nodeMiddleware = new NodeMiddleware(nodes);
        }

        public List<Point> CalculatePath(Node end)
        {
            List<Node> _clearNodes = nodes.Select(n => NodeMiddleware.CloneNode(n)).ToList();
            _clearNodes.FirstOrDefault(n => n.cords == end.cords).properties.Add("end");

            Node start = _clearNodes.FirstOrDefault(n => n.properties.Contains("start"));

            List<Node> openNodes = _clearNodes.OrderBy(n => n.gCost).ToList();

            PriorityQueue<Node, int> priorityQueue = new PriorityQueue<Node, int>();
            priorityQueue.Enqueue(start, start.gCost);

            foreach (var clearNode in _clearNodes)
            {
                if (!clearNode.properties.Contains("start"))
                {
                    // Enqueue all clear nodes with their initial cost
                    clearNode.gCost = int.MaxValue;
                    priorityQueue.Enqueue(clearNode, clearNode.gCost);
                }
            }

            while (priorityQueue.Count > 0)
            {
                Node currentNode = priorityQueue.Peek();
                priorityQueue.Dequeue();

                foreach (Node neighbor in GetNeighbors(_clearNodes, currentNode))
                {
                    int tentativeG = currentNode.gCost + nodeMiddleware.GetDistance(currentNode.cords, neighbor.cords);

                    if (tentativeG < neighbor.gCost)
                    {
                        // This path is the best so far, update the neighbor
                        neighbor.gCost = tentativeG;
                        neighbor.origin.Clear();
                        neighbor.origin.AddRange(currentNode.origin);
                        neighbor.origin.Add(currentNode.cords);
                        priorityQueue.Enqueue(neighbor, neighbor.gCost);
                    }
                }

                if (currentNode.properties.Contains("end"))
                {
                    end.origin.Clear();
                    end.origin.AddRange(currentNode.origin);
                    break;
                }

            }

            List<Point> shortestPath = new List<Point>();

            if (end != null)
            {
                shortestPath.AddRange(end.origin);
                shortestPath.Add(end.cords);
            }

            return shortestPath;
        }

        private static List<Node> GetNeighbors(List<Node> _nodes, Node currentNode)
        {
            List<Node> neighbors = new List<Node>();

            // Define the possible relative positions of neighbors
            int[] dx = { -1, 0, 1, -1, 1, -1, 0, 1 };
            int[] dy = { -1, -1, -1, 0, 0, 1, 1, 1 };

            foreach (int i in Enumerable.Range(0, 8))
            {
                int newX = currentNode.cords.X + dx[i];
                int newY = currentNode.cords.Y + dy[i];

                Node neighbor = _nodes.FirstOrDefault(n => n.cords.X == newX && n.cords.Y == newY);

                if (neighbor != null && !neighbor.properties.Contains("obstacle"))
                {
                    neighbors.Add(neighbor);
                }
            }

            return neighbors;
        }
    }
}
