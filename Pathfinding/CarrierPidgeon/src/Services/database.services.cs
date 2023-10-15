using MongoDB.Driver;

public class DatabaseServices
{
    private readonly IMongoDatabase _database;

    public DatabaseServices(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database:MongoDBConnection");
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase("Database:YourDatabaseName");
    }

    public IMongoCollection<T> GetCollection<T>(string collectionName)
    {
        return _database.GetCollection<T>(collectionName);
    }
}
