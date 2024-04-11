using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitabist.Order.Application.Features.Commands.Address.CreateAddress
{
    public class CreateAddressCommandRequest:IRequest<CreateAddressCommandResponse>
    {
        public int UserId { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}
