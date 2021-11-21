namespace Cakes.Data.DTO.Product
{
    internal class ProductDTO
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
