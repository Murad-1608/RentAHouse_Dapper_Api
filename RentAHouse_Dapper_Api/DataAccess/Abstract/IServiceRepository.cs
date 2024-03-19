using RentAHouse_Dapper_Api.DTOs.ServiceDTOs;

namespace RentAHouse_Dapper_Api.DataAccess.Abstract
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDTO>> GetAllAsync();
        Task Create(CreateServiceDTO createServiceDTO);
        Task Delete(int id);
        Task Update(UpdateServiceDTO updateServiceDTO);
        Task<ResultServiceDTO> GetById(int id);
    }
}
