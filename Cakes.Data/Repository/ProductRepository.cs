using Cakes.Data.Context;
using Cakes.Data.DTO.Product;
using Cakes.Domain.Entity;
using Cakes.Domain.Helpers;

namespace Cakes.Data.Repository
{
    public class ProductRepository : BaseRepository<Product>
    {
        private readonly DataContext _DbContext;
        public ProductRepository(DataContext context) : base(context)
        {
            _DbContext = context;
        }

        public async Task<Pagination> GetAllPagination(string? categoryId, int skip, int take)
        {
            return await GetAllSelect(
            select:
            c => new ProductDTO
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                Price = c.Price,
                ImageUrl = c.ImageUrl
            },
            where: string.IsNullOrEmpty(categoryId) ? c => c.Active : c => c.Active && c.ProductCategory.Id.ToString() == categoryId
            , false, skip, take);
        }

    }
}
