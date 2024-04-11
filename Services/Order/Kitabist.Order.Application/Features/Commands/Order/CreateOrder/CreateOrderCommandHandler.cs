using Kitabist.Order.Application.Common.Interfaces;
using Kitabist.Order.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitabist.Order.Application.Features.Commands.Order.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        private readonly IRepository<Ordering> _repository;

        public CreateOrderCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Ordering()
            {
                TotalPrice = request.TotalPrice,
                UserId = request.UserId,
                OrderDate = request.OrderDate,
            });
            return new CreateOrderCommandResponse { IsSuccess = true };
        }
    }
}
