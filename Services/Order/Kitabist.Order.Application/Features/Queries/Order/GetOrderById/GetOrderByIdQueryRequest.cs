﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitabist.Order.Application.Features.Queries.Order.GetOrderById
{
    public class GetOrderByIdQueryRequest:IRequest<GetOrderByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
