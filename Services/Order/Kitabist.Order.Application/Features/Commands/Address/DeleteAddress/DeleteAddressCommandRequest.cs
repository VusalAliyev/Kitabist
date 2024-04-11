using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitabist.Order.Application.Features.Commands.Address.DeleteAddress
{
    public class DeleteAddressCommandRequest : IRequest<DeleteAddressCommandResponse>
    {
        public int AdressId { get; set; }
    }
}
