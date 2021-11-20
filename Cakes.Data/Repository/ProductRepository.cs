using Cakes.Data.Context;
using Cakes.Domain.Entity;

namespace Cakes.Data.Repository
{
    public class ProductRepository : BaseRepository<Product>
    {
        private readonly DataContext _DbContext;
        public ProductRepository(DataContext context) : base(context)
        {
            _DbContext = context;
        }





    }
}
