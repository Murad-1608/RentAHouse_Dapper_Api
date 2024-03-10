using RentAHouse_Dapper_Api.DTOs.ProductDTOs;

namespace RentAHouse_Dapper_Api.DataAccess.Abstract
{
    public interface IProductRepository
    {
        Task<List<ResultProductDTO>> GetAllAsync();
        Task<List<ResultProductWithCategoryDTO>> GetWithCategory();
    }
}
