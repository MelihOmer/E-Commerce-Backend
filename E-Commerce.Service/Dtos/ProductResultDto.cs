namespace E_Commerce.Service.Dtos
{
    public class ProductResultDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string ImageUrl { get; set; }
        public string ProductTypeName { get; set; }
        public string ProductBrandName { get; set; }

    }
}
