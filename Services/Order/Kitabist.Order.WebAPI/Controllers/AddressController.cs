using Kitabist.Order.Application.Features.Commands.Address.CreateAddress;
using Kitabist.Order.Application.Features.Commands.Address.DeleteAddress;
using Kitabist.Order.Application.Features.Commands.Address.UpdateAddress;
using Kitabist.Order.Application.Features.Queries.Address.GetAddressById;
using Kitabist.Order.Application.Features.Queries.Address.GetAllAddresses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kitabist.Order.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAddress()
        {
            var response = await _mediator.Send(new GetAllAddressesQueryRequest());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(GetAddressByIdQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddAddress(CreateAddressCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok("Address added successfuly");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAddress([FromQuery]DeleteAddressCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok("Address removed successfuly");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok("Address updated successfuly");
        }
    }
}
