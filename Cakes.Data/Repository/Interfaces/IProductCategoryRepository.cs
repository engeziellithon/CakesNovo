using Cakes.Domain.Entity;

namespace Cakes.Data.Repository.Interfaces
{
    public interface IProductCategoryRepository
    {
        Task Save(ProductCategory productCategory);
    }
}