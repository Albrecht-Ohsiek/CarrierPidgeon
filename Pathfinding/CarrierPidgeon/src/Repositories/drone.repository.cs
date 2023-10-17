using CarrierPidgeon.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CarrierPidgeon.Repositories
{
    public class DroneRepository
    {
        private readonly IMongoCollection<Drone> _droneCollection;

        public DroneRepository(DatabaseServices dbContext)
        {
            _droneCollection = dbContext.GetCollection<Drone>("drones");
        }

        //TODO CRUD operations

        // Add drone
        public async Task addDrone(Drone drone)
        {
            await _droneCollection.InsertOneAsync(drone);
        }

        // Retrieve drone information
        public async Task<Drone> GetDroneByDroneId(ObjectId droneId)
        {
            return await _droneCollection.Find(drone => drone._id == droneId).FirstOrDefaultAsync();
        }

        public async Task<Drone> GetDroneByUserId(ObjectId userId)
        {
            
            return await _droneCollection.Find(user => user.userId == userId).FirstOrDefaultAsync();
        }

        // Update an existing drone
        public async Task UpdateDrone(ObjectId droneId, Drone drone)
        {
            var filter = Builders<Drone>.Filter.Eq(drone => drone._id, droneId);
            ReplaceOneResult result = await _droneCollection.ReplaceOneAsync(filter, drone);

        }
    }
}