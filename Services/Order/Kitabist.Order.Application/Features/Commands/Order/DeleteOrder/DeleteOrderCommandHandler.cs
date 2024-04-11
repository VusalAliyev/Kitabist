using Kitabist.Order.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
            var deletedOrder = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(deletedOrder);

            return new DeleteOrderCommandResponse { IsSuccess = true };
        }
    }
}
