using System.Drawing;
using MongoDB.Bson;

namespace CarrierPidgeon.Types{
    public interface IOrder{
        ObjectId _id{get; set;}
        string userId {get; set;}
        Point start{get; set;}
        Point end{get; set;}
        string status{get; set;}
    }
}