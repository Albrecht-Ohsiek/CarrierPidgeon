using CarrierPidgeon.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CarrierPidgeon.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserRepository(DatabaseServices dbContext)
        {
            _userCollection = dbContext.GetCollection<User>("users");
        }


        public Task<User> GetUserByName(string name)
        {
            return _userCollection.Find(user => user.name == name).FirstOrDefaultAsync();
        }

        public Task<User> GetUserByEmail(string email)
        {
            return _userCollection.Find(user => user.email == email).FirstOrDefaultAsync();
        }

        Task<User> IUserRepository.RegisterUser(User user)
        {
            _userCollection.InsertOneAsync(user);
            return Task.FromResult(user);
        }

        // Create a new user
        public async Task CreateUser(User user)
        {
            await _userCollection.InsertOneAsync(user);
        }

        // Retrieve a user
        public async Task<User> GetUserById(ObjectId userId)
        {
            return await _userCollection.Find(user => user._id == userId).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserIdByName(string name)
        {
            
            return await _userCollection.Find(user => user.name == name).FirstOrDefaultAsync();
        }

        // Update an existing user
        public async Task UpdateUser(ObjectId userId, User user)
        {
            var filter = Builders<User>.Filter.Eq(u => u._id, userId);
            ReplaceOneResult result = await _userCollection.ReplaceOneAsync(filter, user);

        }


    }
}