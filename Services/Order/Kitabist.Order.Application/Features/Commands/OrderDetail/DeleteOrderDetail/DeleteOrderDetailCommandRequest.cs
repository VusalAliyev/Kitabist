using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitabist.Order.Application.Features.Commands.OrderDetail.DeleteOrderDetail
{
    public class DeleteOrderDetailCommandRequest:IRequest<DeleteOrderDetailCommandResponse>
    {
        public int Id { get; set; }
    }
}
