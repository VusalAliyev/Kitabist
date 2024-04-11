using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitabist.Order.Application.Features.Queries.Address.GetAddressById
{
    public class GetAddressByIdQueryRequest:IRequest<GetAddressByIdQueryResponse>
    {
        public GetAddressByIdQueryRequest(int id)
        {
            Id= id;
        }
        public int Id { get; set; }
    }
}
