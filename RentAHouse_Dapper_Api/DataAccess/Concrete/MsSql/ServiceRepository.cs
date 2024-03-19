using Dapper;
using RentAHouse_Dapper_Api.DataAccess.Abstract;
using RentAHouse_Dapper_Api.DTOs.ServiceDTOs;
using RentAHouse_Dapper_Api.Models.DapperContext;

namespace RentAHouse_Dapper_Api.DataAccess.Concrete.MsSql
{
    public class ServiceRepository : BaseRepository, IServiceRepository
    {
        public ServiceRepository(Context context) : base(context)
        {
        }

        public async Task Create(CreateServiceDTO createServiceDTO)
        {
            string query = "insert into Services values(@name,@status)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", createServiceDTO.Name);
            parameters.Add("@status", true);

            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task Delete(int id)
        {
            string query = "delete from Services where id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultServiceDTO>> GetAllAsync()
        {
            string query = "select *from Services";

            using (var connection = context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultServiceDTO>(query);

                return values.ToList();
            }
        }

        public async Task<ResultServiceDTO> GetById(int id)
        {
            string query = $"select *from Services where id={id}";

            using (var connection = context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<ResultServiceDTO>(query);

                return value!;
            }
        }

        public async Task Update(UpdateServiceDTO updateServiceDTO)
        {
            string query = "update Services set name=@name,status=@status where id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@name", updateServiceDTO.Name);
            parameters.Add("@status", updateServiceDTO.Status);
            parameters.Add("@id", updateServiceDTO.Id);

            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}

