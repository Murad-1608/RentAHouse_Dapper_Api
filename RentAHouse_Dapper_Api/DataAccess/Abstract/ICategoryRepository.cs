using RentAHouse_Dapper_Api.DTOs.CategoryDTOs;

namespace RentAHouse_Dapper_Api.DataAccess.Abstract
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDTO>> GetAllAsync();
        Task Create(CreateCategoryDTO categoryDTO);
        Task Delete(int id);
        Task Update(UpdateCategoryDTO updateCategoryDTO);
        Task<ResultCategoryDTO> GetById(int id);
    }
}
