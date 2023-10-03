using Microsoft.AspNetCore.Mvc;
using CarrierPidgeon.Services;
using CarrierPidgeon.Models;
using CarrierPidgeon.Middleware;

namespace CarrierPidgeon.Handlers
{
    public class DashboardHandler
    {
        // TODO
        // private readonly IAuthorizationService _authorizationService;
        // private readonly IPermissionService _permissionService;
        // private readonly IQueryService _queryService;
        private readonly GridServices gridServices;

        private List<Node> nodes;

        public DashboardHandler(GridServices gridServices)
        {
            this.gridServices = gridServices;
        }

        public IActionResult SetGridSize([FromBody] Grid grid)
        {
            try
            {
                int width = grid.sizeX;
                int bredth = grid.sizeY;

                nodes = NodeMiddleware.initNodes(width, bredth);

                return new OkObjectResult("Set grid size seccessfully");
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult("Failed to set grid size: " + e.Message);
            }
        }

        // TODO List<Enum> Properties From body
        public IActionResult SetNodes([FromBody] List<Node> nodes)
        {
            try
            {
                foreach (Node node in nodes)
                {
                    int posX = node.posX;
                    int posY = node.posY;
                    bool occupied = node.occupied;
                    bool accessible = node.accessible;
                    int gCost = node.gCost;
                    int hCost = node.hCost;
                    int fCost = node.fCost;
                    List<Enum>? properties = node.properties;
                    List<Node>? origin = node.origin;
                }
                return new OkObjectResult("Set node succesfully");
                
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult("Failed to initialize node " + e.Message);
            }

            throw new NotImplementedException();
        }
    }
}