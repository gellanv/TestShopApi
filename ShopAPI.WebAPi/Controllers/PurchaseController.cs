using Microsoft.AspNetCore.Mvc;
using WebApp.BusinessLogic.Interfaces;

namespace ShopAPI.WebAPi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            this.purchaseService = purchaseService;
        }


        [HttpGet("recent-purchases")]
        public async Task<IActionResult> GetRecentCustomers([FromQuery] int days)
        {
            if (days <= 0)
            {
                return BadRequest("Кількість днів повинна бути більше нуля.");
            }

            try
            {
                var customers = await purchaseService.GetRecentPurphaseAsync(days);

                if (!customers.Any())
                {
                    return NotFound("Немає клієнтів, які здійснили покупки за вказаний період.");
                }

                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Виникла помилка при отриманні даних.");
            }
        }
    }
}
