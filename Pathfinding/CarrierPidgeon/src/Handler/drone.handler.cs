using CarrierPidgeon.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarrierPidgeon.Handlers
{
    class DroneHandler{
        private List<Node> nodes;


        public DroneHandler(List<Node> nodes)
        {
            this.nodes = nodes;
        }

        internal static IActionResult GetPath(List<Node> nodes)
        {
            Node startNode = nodes.FirstOrDefault(n => n.properties.Contains("start"));
            Node endNode = nodes.FirstOrDefault(n => n.properties.Contains("end"));

            //List<Node> path = AStarAlgorithm.calculatePath(nodes, startNode, endNode);
            List<Node> path = new List<Node>();
            path.Add(endNode);

            return new OkObjectResult(path);
        }
    }
}

