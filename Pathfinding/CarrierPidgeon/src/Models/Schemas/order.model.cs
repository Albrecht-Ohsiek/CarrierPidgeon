using System.Drawing;
using CarrierPidgeon.Types;
using MongoDB.Bson;

namespace CarrierPidgeon.Models{
    public class Order : IOrder
    {
        public ObjectId _id { get; set; }
        public string userId {get; set;}
        public Point start { get; set; }
        public Point end { get; set; }
        public string status {get; set;}
    }
}