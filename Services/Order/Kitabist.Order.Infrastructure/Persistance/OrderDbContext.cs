using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kitabist.Order;
using Kitabist.Order.Domain.Entities;

namespace Kitabist.Order.Infrastructure.Persistance
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Domain.Entities.Order> Orderings { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Address> Adresses { get; set; }
    }
}
