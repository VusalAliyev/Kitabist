using Kitabist.Discount.DTOs;

namespace Kitabist.Discount.Services.Interfaces
{
    public interface IDiscountService
    {
        Task CreateDiscountAsync(CreateCouponDto createCouponDto);
        Task UpdateDiscountAsync(UpdateCouponDto updateCouponDto);
        Task<List<GetAllCouponsDto>> GetAllCouponsAsync();
        Task DeleteDiscountAsync(int id);
        Task<GetCouponByIdDto> GetCouponByIdAsync(int id);
    }
}
