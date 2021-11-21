using Cakes.Api.ViewModel;
using Cakes.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Cakes.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductCategoryController : Controller
    {
        [HttpGet(Name = "ProductCategory")]
        public async Task<IActionResult> Get([FromServices] ProductCategoryRepository repo, [FromQuery] BaseVM baseVm)
        {
            var lista = await repo.GetAll(baseVm.Skip, baseVm.Take);

            return Ok(lista);
        }
    }
}
