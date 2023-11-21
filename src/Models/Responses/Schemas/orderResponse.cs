using System.Drawing;

namespace CarrierPidgeon.Models{
    public class OrderResponse
    {
        public string _id { get; set; }
        public string userId {get; set;}
        public Point start { get; set; }
        public Point end { get; set; }
        public string status {get; set;}

        // Default constructor
        public OrderResponse()
        {
        }

        // Parameterized constructor
        public OrderResponse(string orderId, string userId, Point start, Point end, string status)
        {
            this._id = orderId;
            this.userId = userId;
            this.start = start;
            this.end = end;
            this.status = status;
        }
    }
}