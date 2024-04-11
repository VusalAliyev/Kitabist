using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitabist.Order.Application.Features.Queries.Address.GetAllAddresses
{
    public class GetAllAddressesQueryResponse
    {
        public int AdressId { get; set; }
        public int UserId { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}
