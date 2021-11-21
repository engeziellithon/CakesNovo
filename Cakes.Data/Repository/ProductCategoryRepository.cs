using Cakes.Data.Context;
using Cakes.Data.DTO;
using Cakes.Domain.Entity;
using Cakes.Domain.Helpers;

namespace Cakes.Data.Repository
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory>
    {
        public ProductCategoryRepository(DataContext context) : base(context) { }

        public async Task Save(ProductCategory productCategory)
        {
            await AddAsync(productCategory);
        }

        public async Task<Pagination> GetAll(int skip, int take)
        {
            return await GetAllSelect(c => new ProductCategoryDTO { Id = c.Id, Name = c.Name, ImageUrl = c.ImageUrl }, c => c.Active, false, skip, take);
        }
    }
}
