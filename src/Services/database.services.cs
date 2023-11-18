using MongoDB.Driver;

public class DatabaseServices
{
    private readonly IMongoDatabase _database;

    public DatabaseServices(IConfiguration configuration)
    {
        var connectionString = configuration.GetSection("Database:ConnectionString").Value;
        var databaseName = configuration.GetSection("Database:DatabaseName").Value;
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    public IMongoCollection<T> GetCollection<T>(string collectionName)
    {
        return _database.GetCollection<T>(collectionName);
    }

    public static bool TryParseObjectId(string input, out MongoDB.Bson.ObjectId objectId)
    {
        try
        {
            objectId = MongoDB.Bson.ObjectId.Parse(input);
            return true;
        }
        catch (Exception)
        {
            objectId = MongoDB.Bson.ObjectId.Empty; // or some other default value
            return false;
        }
    } 
}
