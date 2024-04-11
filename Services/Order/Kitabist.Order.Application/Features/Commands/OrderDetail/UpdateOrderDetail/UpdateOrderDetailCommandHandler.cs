using Kitabist.Order.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Kitabist.Order.Application.Features.Commands.OrderDetail.UpdateOrderDetail
{
    public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommandRequest, UpdateOrderDetailCommandResponse>
    {
        private readonly IRepository<OrderingDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderingDetail> repository)
        {
            _repository = repository;
        }

        public async Task<UpdateOrderDetailCommandResponse> Handle(UpdateOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            var orderDetail = await _repository.GetByIdAsync(request.OrderDetailId);
            orderDetail.OrderId = request.OrderId;
            orderDetail.ProductPrice = request.ProductPrice;
            orderDetail.ProductName = request.ProductName;
            orderDetail.ProductId = request.ProductId;
            orderDetail.ProductAmount = request.ProductAmount;
            orderDetail.ProductTotalPrice = request.ProductTotalPrice;
            await _repository.UpdateAsync(orderDetail);
            return new UpdateOrderDetailCommandResponse { IsSuccess = true };

        }
    }
}
