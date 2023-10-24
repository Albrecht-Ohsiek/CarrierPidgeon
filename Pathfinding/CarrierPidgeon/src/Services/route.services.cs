using CarrierPidgeon.Models;
using CarrierPidgeon.Repositories;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Route = CarrierPidgeon.Models.Route;

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
            while (true)
            {
                Order order = await _orderRepository.GetFirstOrderByStatus(status);
                if (order != null)
                {
                    Console.WriteLine("Hello Thread");
                }

                Thread.Sleep(10000);
            }
        }

    }
}
