using Microsoft.AspNetCore.Mvc;
using CarrierPidgeon.Services;
using CarrierPidgeon.Models;

namespace CarrierPidgeon.Handlers
{
    public class DashboardHandler
    {
        // TODO
        // private readonly IAuthorizationService _authorizationService;
        // private readonly IPermissionService _permissionService;
        // private readonly IQueryService _queryService;
        private readonly GridServices gridServices;

        public DashboardHandler(GridServices gridServices)
        {
            this.gridServices = gridServices;
        }

        public async Task<IActionResult> SetGridSize([FromBody] Grid grid)
        {
            {
                try
                {
                    int width = grid.sizeX;
                    int bredth = grid.sizeY;

                    Node[,] nodes = nodeServices.initNodes(width, bredth);

                    return new OkObjectResult("Set grid size");
                }
                catch (Exception e)
                {
                    return new BadRequestObjectResult("Failed to set grid size: " + e.Message);
                }
            }
        }

        // TODO List<Enum> Properties From body
        internal Task<IActionResult> SetNodeType()
        {
            throw new NotImplementedException();
        }
    }
}