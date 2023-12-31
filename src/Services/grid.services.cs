using System.Drawing;
using CarrierPidgeon.Middleware;
using CarrierPidgeon.Models;

namespace CarrierPidgeon.Services
{
    public class GridServices
    {
        public Grid grid {get;} = new Grid();
        private List<Node> _nodes = new List<Node>();
        private NodeMiddleware nodeMiddleware;

        private readonly GridConfiguration _configuration;

        public GridServices(GridConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Node> InitializeGrid(){
            for (int i = 0; i < _configuration.width; i++){
                for (int j = 0; j < _configuration.height; j++)
                {
                    Point point = new Point(i, j);
                    _nodes.Add(new Node(point));
                }
            }
            return _nodes;
        }
    }
}