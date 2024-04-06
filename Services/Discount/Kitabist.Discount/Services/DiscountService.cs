using Dapper;
using Kitabist.Discount.DTOs;
using Kitabist.Discount.Entities;
using Kitabist.Discount.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Kitabist.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IConfiguration _configuration;
        public DiscountService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IDbConnection CreateConnection()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            return new SqlConnection(connectionString);
        }
        public async Task CreateDiscountAsync(CreateCouponDto createCouponDto)
        {
            using (var connection = CreateConnection())
            {
              var salam =  await connection.ExecuteAsync("INSERT INTO Coupons (Code, IsActive, Rate, ValidDate) VALUES (@Code, @IsActive, @Rate, @ValidDate)", createCouponDto);
            }
        }

        public async Task DeleteDiscountAsync(int id)
        {
            using (var connection = CreateConnection())
            {
                await connection.ExecuteAsync("DELETE FROM Coupons WHERE CouponId = @CouponId", new { CouponId = id });
            }
        }

        public async Task<List<GetAllCouponsDto>> GetAllCouponsAsync()
        {
            using (var connection = CreateConnection())
            {
                var coupons= await connection.QueryAsync<GetAllCouponsDto>(
                    "Select * from Coupons"
                    );
                return coupons.ToList();
            }
        }

        public async Task<GetCouponByIdDto> GetCouponByIdAsync(int id)
        {
            using (var connection = CreateConnection())
            {
                var coupon= await connection.QueryAsync<GetCouponByIdDto>(
                    "Select * from Coupons where CouponId = @CouponId", new { CouponId = id}
                    );
                return coupon.FirstOrDefault();
            }
        }

        public async Task UpdateDiscountAsync(UpdateCouponDto updateCouponDto)
        {
            using (var connection=CreateConnection())
            {
                await connection.ExecuteAsync("UPDATE Coupons SET Code = @Code, Rate = @Rate, IsActive = @IsActive, ValidDate = @ValidDate WHERE CouponId = @CouponId", updateCouponDto);
            }
        }
    }
}
