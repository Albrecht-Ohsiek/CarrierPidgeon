using CarrierPidgeon.Models;

namespace CarrierPidgeon.Types
{
    public interface IGrid
    {
        Node[,] nodes {get; set;}
    }
}