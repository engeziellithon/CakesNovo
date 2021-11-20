using Cakes.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Cakes.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductCategoryController : Controller
    {
        [HttpGet(Name = "ProductCategory")]
        public async Task<IActionResult> Get([FromServices] ProductCategoryRepository repo)
        {
            var lista = await repo.GetAll();

            return Ok(lista);
        }
    }
}
