using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitabist.Order.Application.Features.Commands.Order.DeleteOrder
{
    public class DeleteOrderCommandRequest:IRequest<DeleteOrderCommandResponse>
    {
        public int Id { get; set; }
    }
}
