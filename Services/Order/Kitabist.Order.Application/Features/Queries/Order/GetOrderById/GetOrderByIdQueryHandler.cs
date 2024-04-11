using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitabist.Order.Application.Features.Queries.Order.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQueryRequest, GetOrderByIdQueryResponse>
    {
        private readonly IRepository<Ordering> _repository;

        public GetOrderByIdQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderByIdQueryResponse> Handle(GetOrderByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetByIdAsync(request.Id);

            return new GetOrderByIdQueryResponse
            {
                OrderDate = order.OrderDate,
                OrderId = order.OrderId,
                OrderDetails = order.OrderDetails,
                TotalPrice = order.TotalPrice,
                UserId = order.UserId
            };
        }
    }
}
