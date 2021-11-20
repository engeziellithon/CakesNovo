using Cakes.Data.Context;
using Cakes.Domain.Entity;
using System.Threading.Tasks;

namespace Cakes.Data.Repository
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory>
    {
        public ProductCategoryRepository(DataContext context) : base(context) { }

        public async Task Save(ProductCategory productCategory)
        {
            await AddAsync(productCategory);
        }
    }
}
