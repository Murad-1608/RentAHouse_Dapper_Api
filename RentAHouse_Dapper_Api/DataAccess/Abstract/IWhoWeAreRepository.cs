using RentAHouse_Dapper_Api.DTOs.CategoryDTOs;
using RentAHouse_Dapper_Api.DTOs.WhoWeAreDTOs;

namespace RentAHouse_Dapper_Api.DataAccess.Abstract
{
    public interface IWhoWeAreRepository
    {
        Task<List<ResultWhoWeAreDTO>> GetAllAsync();
        Task Create(CreateWhoWeAreDTO whoWeAreDTO);
        Task Delete(int id);
        Task Update(UpdateWhoWeAreDTO updateWhoWeAreDTO);
        Task<ResultWhoWeAreDTO> GetById(int id);
    }
}
