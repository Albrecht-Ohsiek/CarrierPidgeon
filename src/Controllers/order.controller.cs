using Microsoft.AspNetCore.Mvc;
using CarrierPidgeon.Repositories;
using CarrierPidgeon.Models;
using MongoDB.Bson;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using CarrierPidgeon.Models.Responses;

namespace CarrierPidgeon.Controllers
{

    [ApiController]
    [Route("/api/orders")]
    [EnableCors("MyCorsPolicy")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        //[Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> RegisterOrder([FromBody] AddOrderRequest order)
        {
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

        //[Authorize]
        [HttpPut("update/{orderId}")]
        public async Task<IActionResult> UpdateStatus([FromRoute] string orderId, [FromBody] UpdateOrderRequest order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            if (DatabaseServices.TryParseObjectId(orderId, out ObjectId objectId))
            {
                Order existingOrder = await _orderRepository.GetOrder(objectId);
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
            else
            {
                return BadRequest(new ErrorResponse("Invalid ObjectId format"));
            }
        }

        //[Authorize]
        [HttpGet("get/status/{status}")]
        public async Task<IActionResult> GetOrderByStatus([FromRoute] string status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            List<Order> orders = await _orderRepository.GetOrderByStatus(status);
            if (orders == null)
            {
                return NotFound(new ErrorResponse("No orders found"));
            }

            List<OrderResponse> orderResponses = new List<OrderResponse>();
            foreach (Order order in orders)
            {
                OrderResponse orderResponse = new OrderResponse
                {
                    _id = order._id.ToString(),
                    userId = order.userId,
                    start = order.start,
                    end = order.end,
                    status = order.status
                };
                orderResponses.Add(orderResponse);
            }

            return Ok(orderResponses);
        }

        //[Authorize]
        [HttpGet("get/user/{userId}")]
        public async Task<IActionResult> GetOrderByUserID([FromRoute] string userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            Order order = await _orderRepository.GetOrderByUserID(userId);
            if (order == null)
            {
                return NotFound(new ErrorResponse("No orders found"));
            }
            OrderResponse orderResponse = new OrderResponse
            {
                _id = order._id.ToString(),
                userId = order.userId,
                start = order.start,
                end = order.end,
                status = order.status
            };

            return Ok(orderResponse);
        }

        //[Authorize]
        [HttpGet("get/order/{orderId}")]
        public async Task<IActionResult> GetOrder([FromRoute] string orderId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            if (DatabaseServices.TryParseObjectId(orderId, out ObjectId objectId))
            {
                Order order = await _orderRepository.GetOrder(objectId);
                if (order == null)
                {
                    return NotFound(new ErrorResponse("Order not found"));
                }
                
                OrderResponse orderResponse = new OrderResponse
                {
                    _id = objectId.ToString(),
                    userId = order.userId,
                    start = order.start,
                    end = order.end,
                    status = order.status
                };

                return Ok(orderResponse);
            }
            else
            {
                return BadRequest(new ErrorResponse("Invalid ObjectId format"));
            }
        }

    }
}