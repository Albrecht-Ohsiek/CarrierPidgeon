using System;
using System.Collections.Generic;
using CarrierPidgeon.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;
using Route = CarrierPidgeon.Models.Route;
using System.Collections;
using Microsoft.VisualBasic;

namespace CarrierPidgeon.Repositories
{
    public class RouteRepository : IRouteRepository
    {

        private readonly IMongoCollection<Route> _routeCollection;

        public RouteRepository(DatabaseServices dbContext)
        {
            _routeCollection = dbContext.GetCollection<Route>("routes");
        }

        public async Task<Route> GetRouteById(ObjectId routeId)
        {
            return await _routeCollection.Find(route => route._id == routeId).FirstOrDefaultAsync();
        }

        public async Task<List<Route>> GetAllRoutes()
        {
            return await _routeCollection.Find(route => true).ToListAsync();
        }

        Task<Route> IRouteRepository.CreateRoute(Route route)
        {
            _routeCollection.InsertOneAsync(route);
            return Task.FromResult(route);
        }

        Task<Route> IRouteRepository.UpdateRoute(ObjectId routeId, Route route)
        {
            var filter = Builders<Route>.Filter.Eq(route => route._id, routeId);
            _routeCollection.ReplaceOneAsync(filter, route);
            return Task.FromResult(route);
        }

        public async Task<Route> GetSingleRouteByStatus(string status)
        {
            return await _routeCollection.Find(route => route.status == status).FirstOrDefaultAsync();
        }
    }
}
