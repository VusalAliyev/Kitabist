using Kitabist.Order.Application.Features.Commands.Address.CreateAddress;
using Kitabist.Order.Application.Features.Commands.Address.DeleteAddress;
using Kitabist.Order.Application.Features.Commands.Address.UpdateAddress;
using Kitabist.Order.Application.Features.Commands.Order.CreateOrder;
using Kitabist.Order.Application.Features.Commands.Order.DeleteOrder;
using Kitabist.Order.Application.Features.Commands.Order.UpdateOrder;
using Kitabist.Order.Application.Features.Queries.Address.GetAddressById;

using Kitabist.Order.Application.Features.Queries.Address.GetAllAddresses;
using Kitabist.Order.Application.Features.Queries.Order.GetAllOrder;
using Kitabist.Order.Application.Features.Queries.Order.GetOrderById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kitabist.Order.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var response = await _mediator.Send(new GetAllOrdersQueryRequest());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var request = new GetOrderByIdQueryRequest(id);
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(CreateOrderCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok("Order added successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrder([FromQuery] DeleteOrderCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok("Order removed successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrderCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok("Order updated successfully");
        }


    }
}
