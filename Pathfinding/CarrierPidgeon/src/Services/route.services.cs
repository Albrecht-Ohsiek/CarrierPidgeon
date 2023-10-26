using System.Drawing;
using CarrierPidgeon.Algorithms;
using CarrierPidgeon.Middleware;
using CarrierPidgeon.Models;
using CarrierPidgeon.Repositories;
using Route = CarrierPidgeon.Models.Route;

namespace CarrierPidgeon.Services
{
    public class RouteService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IRouteRepository _routeRepository;
        const string status = "open";
        private readonly List<Node> nodes;

        public RouteService(List<Node> nodes, IOrderRepository orderRepository, IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
            _orderRepository = orderRepository;
            this.nodes = nodes;
        }

        public void startCalculateRouteThread()
        {
            Thread thread = new Thread(calculateRoute);
            thread.IsBackground = true;
            thread.Start();
        }

        private async void calculateRoute()
        {
            bool locked = false;
            while (true)
            {
                if (locked == false)
                {
                    Order order = await _orderRepository.GetFirstOrderByStatus(status);
                    try
                    {
                        if (order != null)
                        {
                            Node node = nodes.FirstOrDefault(n => n.cords == order.end);
                            Node endNode = NodeMiddleware.CloneNode(node);

                            locked = true;
                            Dijkstra pathAlgo = new Dijkstra(nodes);
                            List<Point> path = pathAlgo.CalculatePath(endNode);

                            if (path.Count > 0)
                            {
                                Route route = new Route
                                {
                                    status = "open",
                                    path = path
                                };
                                await _routeRepository.CreateRoute(route);

                                order.status = "pending";
                                await _orderRepository.UpdateStatus(order._id, order);

                                Console.WriteLine("Order route calculated");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        locked = false;
                    }

                }

                Thread.Sleep(10000);
            }
        }

    }
}
