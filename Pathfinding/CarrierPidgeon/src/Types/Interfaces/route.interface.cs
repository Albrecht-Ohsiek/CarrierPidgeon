using System.Drawing;
using MongoDB.Bson;

namespace CarrierPidgeon.Types
{
    public interface IRoute
    {
        ObjectId _id {get; set;}
        string status {get; set;}
        List<Point> path {get; set;}
    }
}