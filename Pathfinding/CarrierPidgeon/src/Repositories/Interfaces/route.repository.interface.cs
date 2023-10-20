using CarrierPidgeon.Models;
using MongoDB.Bson;
using Route = CarrierPidgeon.Models.Route;

namespace CarrierPidgeon.Repositories{
    public interface IRouteRepository{
        Task<List<Route>> GetAllRoutes();

        Task<Route> GetRouteById(ObjectId id);

        Task<Route> CreateRoute(Route route);

        Task<Route> UpdateRoute(ObjectId id, Route route);
    }
}