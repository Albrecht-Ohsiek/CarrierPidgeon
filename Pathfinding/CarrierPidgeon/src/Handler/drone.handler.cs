using CarrierPidgeon.Models;
using CarrierPidgeon.Types;
using CarrierPidgeon.Algorithms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

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
            Node startNode = nodes.FirstOrDefault(n => n.properties.Contains(UniqueNodeProperties.Start));
            Node endNode = nodes.FirstOrDefault(n => n.properties.Contains(UniqueNodeProperties.End));

            //List<Node> path = AStarAlgorithm.calculatePath(nodes, startNode, endNode);
            List<Node> path = new List<Node>();
            path.Add(nodes.FirstOrDefault(n => n.properties.Contains(UniqueNodeProperties.End)));

            return new OkObjectResult(path);
        }
    }
}

