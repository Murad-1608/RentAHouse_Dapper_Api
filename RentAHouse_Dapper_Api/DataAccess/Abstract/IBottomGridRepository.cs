using RentAHouse_Dapper_Api.DTOs.BottomGridDTOS;

namespace RentAHouse_Dapper_Api.DataAccess.Abstract
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDTO>> GetAllAsync();
        Task Create(CreateBottomGridDTO BottomGridDTO);
        Task Delete(int id);
        Task Update(UpdateBottomGridDTO updateBottomGridDTO);
        Task<ResultBottomGridDTO> GetById(int id);
    }
}
