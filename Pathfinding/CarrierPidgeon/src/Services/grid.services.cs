using System.Drawing;
using CarrierPidgeon.Models;

namespace CarrierPidgeon.Services
{
    public class GridServices
    {
        public Grid grid {get;} = new Grid();

        private readonly GridConfiguration _configuration;

        public GridServices(GridConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Node> InitializeGrid(){
            List<Node> nodes = new List<Node>();
            for (int i = 0; i < _configuration.width; i++){
                for (int j = 0; j < _configuration.height; j++)
                {
                    Point point = new Point(i, j);
                    nodes.Add(new Node(point));
                }
            }
            return nodes;
        }

        public static void InitializeNodes(){
            
        } 
    }
}