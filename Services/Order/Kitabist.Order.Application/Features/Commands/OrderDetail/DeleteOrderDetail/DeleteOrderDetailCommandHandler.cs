using Kitabist.Order.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitabist.Order.Application.Features.Commands.OrderDetail.DeleteOrderDetail
{
    public class DeleteOrderDetailCommandHandler : IRequestHandler<DeleteOrderDetailCommandRequest, DeleteOrderDetailCommandResponse>
    {
        private readonly IRepository<OrderingDetail> _repository;

        public DeleteOrderDetailCommandHandler(IRepository<OrderingDetail> repository)
        {
            _repository = repository;
        }

        public async Task<DeleteOrderDetailCommandResponse> Handle(DeleteOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            //var deletedOrderDetail = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(request.Id);

            return new DeleteOrderDetailCommandResponse { IsSuccess = true };
        }
    }
}

