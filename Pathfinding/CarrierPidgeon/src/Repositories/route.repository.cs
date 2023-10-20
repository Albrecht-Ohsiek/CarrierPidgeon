using System;
using System.Collections.Generic;
using CarrierPidgeon.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;
using Route = CarrierPidgeon.Models.Route;

namespace CarrierPidgeon.Repositories
{
    public class RouteRepository
    {
        private readonly IMongoCollection<Route> _routes;

        public RouteRepository(DatabaseServices dbContext)
        {
            _routes = dbContext.GetCollection<Route>("routes");
        }

        public async Task<List<Route>> GetAllRoutesAsync()
        {
            return await _routes.Find(route => true).ToListAsync();
        }

        public async Task<Route> GetRouteByIdAsync(ObjectId id)
        {
            return await _routes.Find(route => route._id == id).FirstOrDefaultAsync();
        }

        public async Task CreateRouteAsync(Route route)
        {
            await _routes.InsertOneAsync(route);
        }

        public async Task UpdateRouteAsync(ObjectId id, Route route)
        {
            await _routes.ReplaceOneAsync(r => r._id == id, route);
        }

        public async Task DeleteRouteAsync(ObjectId id)
        {
            await _routes.DeleteOneAsync(r => r._id == id);
        }
    }
}
