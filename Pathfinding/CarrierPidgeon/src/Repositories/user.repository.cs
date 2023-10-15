using CarrierPidgeon.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CarrierPidgeon.Repositories
{
    public class UserRepository
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserRepository(DatabaseServices dbContext)
        {
            _userCollection = dbContext.GetCollection<User>("users");
        }

        //TODO CRUD operations

        // Create a new user
        public async Task CreateUser(User user)
        {
            await _userCollection.InsertOneAsync(user);
        }

        // Retrieve a user
        public async Task<User> GetUserById(ObjectId userId)
        {
            return await _userCollection.Find(user => user.userId == userId).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByName(string name)
        {
            return await _userCollection.Find(user => user.name == name).FirstOrDefaultAsync();
        }

        // Update an existing user
        public async Task UpdateUser(ObjectId userId, User user)
        {
            var filter = Builders<User>.Filter.Eq(user => user.userId, user.userId);
            await _userCollection.ReplaceOneAsync(filter, user);
        }
    }
}