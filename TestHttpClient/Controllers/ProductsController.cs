using Microsoft.AspNetCore.Mvc;
using TestHttpClient.Services;

namespace TestHttpClient.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ICatalogService _catalogService;
        public ProductController(ICatalogService service)
        {
            _catalogService = service;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await _catalogService.GetAll();

                return Ok(products);
            }
            catch (Exception)
            {
                return  StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
