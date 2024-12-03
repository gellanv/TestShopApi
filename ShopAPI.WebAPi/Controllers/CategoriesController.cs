using Microsoft.AspNetCore.Mvc;
using WebApp.BusinessLogic.Interfaces;
using WebApp.BusinessLogic.Models.Response;

namespace ShopAPI.WebAPi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        this.categoryService = categoryService;
    }

    [HttpGet("popular/{customerId}")]
    public async Task<ActionResult<IEnumerable<PopularCategory>>> GetPopularCategories(int customerId)
    {
        try
        {
            var categories = await categoryService.GetCategoriesByCustomerAsync(customerId);

            return Ok(categories);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { Message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Сталася помилка.", Details = ex.Message });
        }
    }
}
