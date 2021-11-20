namespace Cakes.Domain.Helpers
{
    public class Pagination
    {
        public int Total { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public object? Data { get; set; }
    }
}
