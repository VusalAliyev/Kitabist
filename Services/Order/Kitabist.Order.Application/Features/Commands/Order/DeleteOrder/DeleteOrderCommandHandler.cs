using Kitabist.Order.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ordering = Kitabist.Order.Domain.Entities.Order;


namespace Kitabist.Order.Application.Features.Commands.Order.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommandRequest, DeleteOrderCommandResponse>
    {
        private readonly IRepository<Ordering> _repository;

        public DeleteOrderCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<DeleteOrderCommandResponse> Handle(DeleteOrderCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);

            return new DeleteOrderCommandResponse { IsSuccess = true };
        }
    }
}
