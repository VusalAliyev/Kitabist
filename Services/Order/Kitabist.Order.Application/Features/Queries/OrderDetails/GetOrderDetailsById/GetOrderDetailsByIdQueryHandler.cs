using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitabist.Order.Application.Features.Queries.OrderDetails.GetOrderDetailsById
{
    public class GetOrderDetailsByIdQueryHandler : IRequestHandler<GetOrderDetailsByIdQueryRequest, GetOrderDetailsByIdQueryResponse>
    {
        private readonly IRepository<OrderingDetail> _repository;

        public GetOrderDetailsByIdQueryHandler(IRepository<OrderingDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailsByIdQueryResponse> Handle(GetOrderDetailsByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var orderDetails = await _repository.GetByIdAsync(request.Id);

            return new GetOrderDetailsByIdQueryResponse
            {
                OrderDetailId = orderDetails.OrderId,
                OrderId = orderDetails.OrderId,
                ProductAmount = orderDetails.ProductAmount,
                ProductId = orderDetails.ProductId,
                ProductName = orderDetails.ProductName,
                ProductPrice = orderDetails.ProductPrice,
                ProductTotalPrice = orderDetails.ProductTotalPrice
            };
        }
    }
}
