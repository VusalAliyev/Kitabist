using Kitabist.Discount.DTOs;
using Kitabist.Discount.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Kitabist.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCoupons()
        {
            var coupons = await _discountService.GetAllCouponsAsync();
            return Ok(coupons);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCouponById(int id)
        {
           var coupon = await _discountService.GetCouponByIdAsync(id);
            return Ok(coupon);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CreateCouponDto createCouponDto)
        {
            await _discountService.CreateDiscountAsync(createCouponDto);
            return Ok("Copon created");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCoupon(int id)
        {
            await _discountService.DeleteDiscountAsync(id);
            return Ok("Coupon deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponDto updateCouponDto)
        {
            await _discountService.UpdateDiscountAsync(updateCouponDto);
            return Ok("Coupon updated");
        }
    }
}
