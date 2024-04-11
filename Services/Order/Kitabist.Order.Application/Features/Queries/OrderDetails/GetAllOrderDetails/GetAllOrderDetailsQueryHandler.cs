using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitabist.Order.Application.Features.Queries.OrderDetails.GetAllOrderDetails
{
    public class GetAllOrderDetailsQueryHandler : IRequestHandler<GetAllOrderDetailsQueryRequest, List<GetAllOrderDetailsQueryResponse>>
    {
        private readonly IRepository<OrderingDetail> _repository;

        public GetAllOrderDetailsQueryHandler(IRepository<OrderingDetail> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllOrderDetailsQueryResponse>> Handle(GetAllOrderDetailsQueryRequest request, CancellationToken cancellationToken)
        {
            var orderDetails = await _repository.GetAllAsync();

            return orderDetails.Select(o => new GetAllOrderDetailsQueryResponse
            {
                OrderDetailId = o.OrderDetailId,
                OrderId = o.OrderId,
                ProductAmount = o.ProductAmount,
                ProductId = o.ProductId,
                ProductName = o.ProductName,
                ProductPrice = o.ProductPrice,
                ProductTotalPrice = o.ProductTotalPrice,
            }).ToList();
        }
    }
}
