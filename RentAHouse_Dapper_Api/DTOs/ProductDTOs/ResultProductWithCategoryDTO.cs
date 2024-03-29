﻿namespace RentAHouse_Dapper_Api.DTOs.ProductDTOs
{
    public class ResultProductWithCategoryDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string CategoryName { get; set; }
        public string CoverImage { get; set; }
        public string Type { get; set; }
    }
}
