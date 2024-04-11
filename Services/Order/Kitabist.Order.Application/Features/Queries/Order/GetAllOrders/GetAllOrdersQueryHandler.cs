using Kitabist.Order.Application.Features.Queries.Order.GetAllOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kitabist.Order.Application.Features.Queries.Order.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQueryRequest, List<GetAllOrdersQueryResponse>>
    {
        private readonly IRepository<Ordering> _repository;

        public GetAllOrdersQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllOrdersQueryResponse>> Handle(GetAllOrdersQueryRequest request, CancellationToken cancellationToken)
        {
            var orders = await _repository.GetAllAsync();

            return orders.Select(o => new GetAllOrdersQueryResponse
            {
                UserId = o.UserId,
                OrderDate = o.OrderDate,
                OrderDetails = o.OrderDetails,
                TotalPrice = o.TotalPrice
            }).ToList();
        }
    }
}
