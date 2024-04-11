using Kitabist.Order.Application.Common.Interfaces;
using Kitabist.Order.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kitabist.Order.Application.Features.Commands.OrderDetail.CreateOrderDetail
{
    public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommandRequest, CreateOrderDetailCommandResponse>
    {
        private readonly IRepository<OrderingDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderingDetail> repository)
        {
            _repository = repository;
        }

        public async Task<CreateOrderDetailCommandResponse> Handle(CreateOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new OrderingDetail
            {
                OrderId = request.OrderId,
                ProductAmount = request.ProductAmount,
                ProductId = request.ProductId,
                ProductName = request.ProductName,
                ProductPrice = request.ProductPrice,
                ProductTotalPrice = request.ProductTotalPrice
            });
            return new CreateOrderDetailCommandResponse { IsSuccess = true };
        }
    }
}
