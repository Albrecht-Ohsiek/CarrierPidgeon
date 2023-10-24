using CarrierPidgeon.Models;
using CarrierPidgeon.Repositories;

namespace CarrierPidgeon.Services
{
    public class RouteService
    {
        private readonly IOrderRepository _orderRepository;
        const string status = "open";

        public RouteService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
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
                            locked = true;

                            Console.WriteLine("Hello Thread");             
                        }
                    }
                    catch (Exception ex){
                        Console.WriteLine(ex.Message);
                    }
                    finally{
                        locked = false;
                    }

                }

                Thread.Sleep(10000);
            }
        }

    }
}
