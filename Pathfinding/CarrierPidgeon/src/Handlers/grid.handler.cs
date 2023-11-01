using CarrierPidgeon.Middleware;
using CarrierPidgeon.Models;
using Microsoft.IdentityModel.Tokens;

namespace CarrierPidgeon.Handlers
{
    public class GridHandler
    {

        private readonly List<Node> nodes;

        public GridHandler(List<Node> nodes)
        {
            this.nodes = nodes;
        }

        public static List<GridInfoResponse> GetGrid(List<Node> nodes)
        {
            List<Node> clonedNodes = nodes.Select(n => NodeMiddleware.CloneNode(n)).ToList();
            List<GridInfoResponse> gridInfoList = clonedNodes.Select(node => new GridInfoResponse
            {
                cords = node.cords,
                occupied = node.occupied,
                accessible = node.accessible,
                properties = node.properties
            }).ToList();

            return gridInfoList;
        }

        public static List<GridInfoResponse> GetGridCrucial(List<Node> nodes)
        {
            List<Node> clonedNodes = nodes.Select(n => NodeMiddleware.CloneNode(n)).ToList();
            List<GridInfoResponse> gridInfoList = clonedNodes
                .Where(node => !node.properties.IsNullOrEmpty())
                .Select(node => new GridInfoResponse
                    {
                        cords = node.cords,
                        occupied = node.occupied,
                        accessible = node.accessible,
                        properties = node.properties
                    })
                    .ToList();

            return gridInfoList;
        }
    }
}