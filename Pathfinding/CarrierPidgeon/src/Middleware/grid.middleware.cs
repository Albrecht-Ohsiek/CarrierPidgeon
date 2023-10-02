// TODO
using CarrierPidgeon.Models;
using CarrierPidgeon.Services;

namespace CarrierPidgeon.Middleware
{
    public class GridMiddleware
    {
        public static Node[,] initGrid()
        {
            return GridServices.InitializeNodes();
        }
    }
}