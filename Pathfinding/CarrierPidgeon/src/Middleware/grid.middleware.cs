// TODO
using CarrierPidgeon.Models;
using CarrierPidgeon.Services;

namespace CarrierPidgeon.Middleware
{
    public class GridMiddleware
    {
        private readonly GridConfiguration _configuration;

        public GridMiddleware(GridConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Node> InitializeGrid(){
            GridServices gridServices = new GridServices(_configuration);
            return gridServices.InitializeGrid();
        }

        public static void InitializeNodes(){
            GridServices.InitializeNodes();
        }
    }
}