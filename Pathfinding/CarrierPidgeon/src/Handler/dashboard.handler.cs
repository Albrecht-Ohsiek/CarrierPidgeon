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

        public DashboardHandler(GridServices gridServices, List<Node> nodes)
        {
            this.gridServices = gridServices;
            this.nodes = nodes;
        }

        public IActionResult LoginUser([FromBody] User user)
        {
            try{
                return new OkObjectResult("User Logged in");
            }
            catch{
                return new BadRequestObjectResult("Login failed");
            }
        }

        // TODO List<Enum> Properties From body
        public IActionResult SetNodes([FromBody] List<Node> updatedNodes)
        {
            try
            {
                foreach (Node updatedNode in updatedNodes)
                {
                    Node node = nodes.FirstOrDefault(n => n.cords.X == updatedNode.cords.X && n.cords.Y == updatedNode.cords.Y);

                    if (node != null)
                    {
                        node.cords = updatedNode.cords;
                        node.occupied = updatedNode.occupied;
                        node.accessible = updatedNode.accessible;
                        node.gCost = updatedNode.gCost;
                        node.hCost = updatedNode.hCost;
                        node.fCost = updatedNode.fCost;
                        node.properties = updatedNode.properties;
                        node.origin = updatedNode.origin;
                    }
                    else{
                        throw new NullReferenceException();
                    }           
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