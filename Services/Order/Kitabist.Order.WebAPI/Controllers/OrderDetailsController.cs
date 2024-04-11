using Kitabist.Order.Application.Features.Commands.Address.CreateAddress;
using Kitabist.Order.Application.Features.Commands.Address.DeleteAddress;
using Kitabist.Order.Application.Features.Commands.Address.UpdateAddress;
using Kitabist.Order.Application.Features.Commands.Order.DeleteOrder;
using Kitabist.Order.Application.Features.Commands.OrderDetail.CreateOrderDetail;
using Kitabist.Order.Application.Features.Commands.OrderDetail.DeleteOrderDetail;
using Kitabist.Order.Application.Features.Commands.OrderDetail.UpdateOrderDetail;
using Kitabist.Order.Application.Features.Queries.OrderDetails.GetAllOrderDetails;
using Kitabist.Order.Application.Features.Queries.OrderDetails.GetOrderDetailsById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kitabist.Order.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderDetails()
        {
            var response = await _mediator.Send(new GetAllOrderDetailsQueryRequest());
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailsById(int id)
        {
            var request = new GetOrderDetailsByIdQueryRequest(id);
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrderDetails(CreateOrderDetailCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok("Order Details added successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrderDetails([FromQuery] DeleteOrderDetailCommandRequest request)
        {
            await _mediator.Send(request);  
            return Ok("Order Details removed successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetails(UpdateOrderDetailCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok("Order Details updated successfully");
        }
    }
}
