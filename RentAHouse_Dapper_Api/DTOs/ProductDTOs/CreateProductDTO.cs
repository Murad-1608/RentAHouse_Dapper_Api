namespace RentAHouse_Dapper_Api.DTOs.ProductDTOs
{
    public class CreateProductDTO
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string CoverImage { get; set; }
        public string Type { get; set; }
    }
}
