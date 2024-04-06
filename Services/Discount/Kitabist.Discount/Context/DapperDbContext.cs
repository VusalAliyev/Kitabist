using Kitabist.Discount.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kitabist.Discount.Context
{
    public class DapperDbContext : DbContext
    {
        public DapperDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Coupon> Coupons { get; set; }


    }
}
