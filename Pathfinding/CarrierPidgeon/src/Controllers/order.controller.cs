using Microsoft.AspNetCore.Mvc;
using CarrierPidgeon.Repositories;
using CarrierPidgeon.Models;
using CarrierPidgeon.Services.Responses;
using MongoDB.Bson;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace CarrierPidgeon.Controllers{
    
    [ApiController]
    [Route("/api/orders")]
    [EnableCors("MyCorsPolicy")]
    public class OrderController : ControllerBase{
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> RegisterOrder ([FromBody] AddOrderRequest order){
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }
            
            Order _order = new Order()
            {
                userId = order.userId,
                start = order.start,
                end = order.end,
                status = "open"
            };

            await _orderRepository.RegisterOrder(_order);
            return Ok();          
        }

        [Authorize]
        [HttpPut("update/{orderId}")]
        public async Task<IActionResult> UpdateStatus ([FromRoute] ObjectId orderId, [FromBody] UpdateOrderRequest order){
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            Order existingOrder = await _orderRepository.GetOrder(orderId);
                if (existingOrder == null)
                {
                    return NotFound(new ErrorResponse("Order not found"));
                }

            Order _order = new Order()
            {
                _id = existingOrder._id,
                start = existingOrder.start,
                end = existingOrder.end,
                status = order.status
            };

            await _orderRepository.RegisterOrder(_order);
            return Ok(_order);   
        }
        
        [Authorize]
        [HttpGet("get/status/{status}")]
        public async Task<IActionResult> GetOrderByStatus ([FromRoute] string status){
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            List<Order> order = await _orderRepository.GetOrderByStatus(status);
            if (order == null)
            {
                return NotFound(new ErrorResponse("No orders found"));
            }

            return Ok(order);
        }

        [Authorize]
        [HttpGet("get/user/{userId}")]
        public async Task<IActionResult> GetOrderByUserID ([FromRoute] string userId){
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            Order order = await _orderRepository.GetOrderByUserID(userId);
            if (order == null)
            {
                return NotFound(new ErrorResponse("No orders found"));
            }

            return Ok(order);
        }

        [Authorize]
        [HttpGet("get/order/{orderId}")]
        public async Task<IActionResult> GetOrder ([FromRoute] ObjectId orderId){
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            Order order = await _orderRepository.GetOrder(orderId);
            if (order == null)
            {
                return NotFound(new ErrorResponse("No orders found"));
            }

            return Ok(order);
        }

    }
}