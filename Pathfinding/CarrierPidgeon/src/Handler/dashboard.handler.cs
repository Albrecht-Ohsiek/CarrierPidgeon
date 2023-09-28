using Microsoft.AspNetCore.Mvc;
using CarrierPidgeon.Services;
using CarrierPidgeon.Models;

namespace CarrierPidgeon.Handlers
{
    public class DashboardHandler
    {
        // private readonly IAuthorizationService _authorizationService;
        // private readonly IPermissionService _permissionService;
        // private readonly IQueryService _queryService;
        private readonly Grid_Services gridServices;

        public DashboardHandler(Grid_Services gridServices)
        {
            this.gridServices = gridServices;
        }

        public async Task<IActionResult> SetGridSize([FromBody] Grid_Model gridModel)
        {
            {
                try
                {
                    int width = gridModel.sizeX;
                    int bredth = gridModel.sizeY;

                    Node[,] nodes = node_services.initNodes(width, bredth);

                    return new OkObjectResult("Set grid size");
                }
                catch (Exception e)
                {
                    return new BadRequestObjectResult("Failed to set grid size: " + e.Message);
                }
            }
        }

        internal Task<IActionResult> SetNodeType()
        {
            throw new NotImplementedException();
        }
    }
}