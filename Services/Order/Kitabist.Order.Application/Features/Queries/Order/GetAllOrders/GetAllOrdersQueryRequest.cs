﻿using Kitabist.Order.Application.Features.Queries.Order.GetAllOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitabist.Order.Application.Features.Queries.Order.GetAllOrder
{
    public class GetAllOrdersQueryRequest : IRequest<List<GetAllOrdersQueryResponse>>
    {
    }
}
