using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitabist.Order.Application.Features.Queries.OrderDetails.GetOrderDetailsById
{
    public class GetOrderDetailsByIdQueryRequest:IRequest<GetOrderDetailsByIdQueryResponse>
    {
        public GetOrderDetailsByIdQueryRequest(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
