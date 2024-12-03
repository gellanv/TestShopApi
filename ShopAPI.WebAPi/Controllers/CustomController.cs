using Microsoft.AspNetCore.Mvc;
using WebApp.BusinessLogic.Interfaces;
using WebApp.BusinessLogic.Models.Response;

namespace ShopAPI.WebAPi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet("birthdays")]
        public async Task<ActionResult<IEnumerable<BirthdayCustomer>>> GetBirthdayCustomers([FromQuery] DateTime date)
        {
            if (date == default)
            {
                return BadRequest("Невірно вказана дата. Формат має бути yyyy-MM-dd.");
            }

            try
            {
                var customers = await customerService.GetBirthdayCustomersAsync(date);

                if (customers == null || !customers.Any())
                {
                    return NotFound("Не знайдено клієнтів із днем народження у вказаний день.");
                }

                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Виникла внутрішня помилка сервера.");
            }
        }
    }
}
