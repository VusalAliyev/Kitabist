using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitabist.Order.Application.Features.Commands.Order.CreateOrder
{
    public class CreateOrderCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }
}
