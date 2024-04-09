using Kitabist.Order.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ordering = Kitabist.Order.Domain.Entities.Order;

namespace Kitabist.Order.Application.Features.Commands.Order.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommandRequest, UpdateOrderCommandResponse>
    {
        private readonly IRepository<Ordering> _repository;

        public UpdateOrderCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<UpdateOrderCommandResponse> Handle(UpdateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetByIdAsync(request.OrderingId);
            order.OrderDate = request.OrderDate;
            order.TotalPrice = request.TotalPrice;
            order.UserId = request.UserId;

            await _repository.UpdateAsync(order);

            return new UpdateOrderCommandResponse { IsSuccess = true };

        }
    }
}
