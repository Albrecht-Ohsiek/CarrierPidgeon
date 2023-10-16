using MongoDB.Driver;

public class DatabaseServices
{
    private readonly IConfiguration _configuration;
    private readonly IMongoDatabase _database;

    public DatabaseServices(IConfiguration configuration)
    {
        _configuration = configuration;

        var connectionString = _configuration.GetSection("Database:ConnectionString").Value;
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(_configuration.GetSection("Database:DatabaseName").Value);
    }

    public IMongoCollection<T> GetCollection<T>(string collectionName)
    {
        return _database.GetCollection<T>(collectionName);
    }
}
