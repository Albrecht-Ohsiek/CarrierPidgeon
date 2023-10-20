using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace CarrierPidgeon.Models
{
    public class AddOrderRequest
    {
        public string userId {get; set;}
        public Point start { get; set; }
        public Point end { get; set; }
    }
}