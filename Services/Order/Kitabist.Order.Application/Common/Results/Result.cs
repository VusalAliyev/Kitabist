using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitabist.Order.Application.Common.Results
{
    public abstract class Result
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }
}
