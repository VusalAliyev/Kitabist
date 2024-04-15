﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitabist.Order.Application.Features.Commands.OrderDetail.UpdateOrderDetail
{
    public class UpdateOrderDetailCommandRequest:IRequest<UpdateOrderDetailCommandResponse>
    {
        public int OrderDetailId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductAmount { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public int OrderId { get; set; }
    }
}
