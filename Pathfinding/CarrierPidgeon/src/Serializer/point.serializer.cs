using System.Drawing;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace CarrierPidgeon.Serializer
{
    public class PointSerializer : SerializerBase<Point>
{
public override Point Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
{
    var bsonReader = context.Reader;
    if (bsonReader.CurrentBsonType != BsonType.Document)
    {
        bsonReader.ReadStartDocument();
    }

    var bsonDocument = BsonDocumentSerializer.Instance.Deserialize(context);

    int x = bsonDocument["X"].AsInt32;
    int y = bsonDocument["Y"].AsInt32;

    return new Point(x, y);
}

    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Point value)
    {
        var bsonWriter = context.Writer;
        bsonWriter.WriteStartDocument();
        bsonWriter.WriteName("X");
        bsonWriter.WriteInt32(value.X);
        bsonWriter.WriteName("Y");
        bsonWriter.WriteInt32(value.Y);
        bsonWriter.WriteEndDocument();
    }
}
}