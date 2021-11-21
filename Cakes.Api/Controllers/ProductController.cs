using Cakes.Api.ViewModel.Product;
using Cakes.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Cakes.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        [HttpGet(Name = "Product")]
        public async Task<IActionResult> Get([FromServices] ProductRepository repo, [FromQuery] GetAllProductVM getAllProductVM)
        {
            var lista = await repo.GetAllPagination(getAllProductVM.CategoryId, getAllProductVM.Skip, getAllProductVM.Take);

            return Ok(lista);
        }


        //[HttpGet(Name = "ProductAll")]
        //public async Task<IActionResult> GetAllProducts([FromServices] ProductRepository repo)
        //{
        //    var lista = await repo.GetAll();

        //    return Ok(lista);
        //}
    }
}
