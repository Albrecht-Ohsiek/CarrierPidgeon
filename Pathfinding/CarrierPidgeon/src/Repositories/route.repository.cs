using System;
using System.Collections.Generic;
using CarrierPidgeon.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace CarrierPidgeon.Repositories
{
    public class RouteRepository
    {
        private readonly IMongoCollection<Route> _routes;

        public RouteRepository(IMongoDatabase dbContext)
        {
            _routes = database.GetCollection<Route>("Routes");
        }

        public async Task<List<Route>> GetAllRoutesAsync()
        {
            return await _routes.Find(route => true).ToListAsync();
        }

        public async Task<Route> GetRouteByIdAsync(string id)
        {
            return await _routes.Find(route => route._id == id).FirstOrDefaultAsync();
        }

        public async Task CreateRouteAsync(Route route)
        {
            await _routes.InsertOneAsync(route);
        }

        public async Task UpdateRouteAsync(string id, Route route)
        {
            await _routes.ReplaceOneAsync(r => r._id == id, route);
        }

        public async Task DeleteRouteAsync(string id)
        {
            await _routes.DeleteOneAsync(r => r._id == id);
        }
    }
}
