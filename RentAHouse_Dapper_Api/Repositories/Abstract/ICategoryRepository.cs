using RentAHouse_Dapper_Api.DTOs.CategoryDTOs;

namespace RentAHouse_Dapper_Api.Repositories.Abstract
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDTO>> GetAllAsync();
        Task CreateCategory(CreateCategoryDTO categoryDTO);
       
    }
}
