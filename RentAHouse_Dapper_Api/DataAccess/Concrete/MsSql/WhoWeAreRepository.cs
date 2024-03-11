using Dapper;
using RentAHouse_Dapper_Api.DataAccess.Abstract;
using RentAHouse_Dapper_Api.DTOs.CategoryDTOs;
using RentAHouse_Dapper_Api.DTOs.WhoWeAreDTOs;
using RentAHouse_Dapper_Api.Models.DapperContext;

namespace RentAHouse_Dapper_Api.DataAccess.Concrete.MsSql
{
    public class WhoWeAreRepository : IWhoWeAreRepository
    {
        private readonly Context context;
        public WhoWeAreRepository(Context context)
        {
            this.context = context;
        }

        public async Task Create(CreateWhoWeAreDTO whoWeAreDTO)
        {
            string query = "insert into WhoWeAreDetails values(@title,@subtitle,@description1,@description2)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", whoWeAreDTO.Title);
            parameters.Add("@subtitle", whoWeAreDTO.SubTitle);
            parameters.Add("@description1", whoWeAreDTO.Description1);
            parameters.Add("@description2", whoWeAreDTO.Description2);

            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task Delete(int id)
        {
            string query = $"delete from WhoWeAreDetails where id={id}";

            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query);
            }
        }

        public async Task<List<ResultWhoWeAreDTO>> GetAllAsync()
        {
            string query = "select *from WhoWeAreDetails";

            using (var connection = context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreDTO>(query);

                return values.ToList();
            }
        }

        public async Task<ResultWhoWeAreDTO> GetById(int id)
        {
            string query = "select *from WhoWeAreDetails where id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = context.CreateConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<ResultWhoWeAreDTO>(query, parameters);

                return result!;
            }
        }

        public async Task Update(UpdateWhoWeAreDTO updateWhoWeAreDTO)
        {
            string query = "update WhoWeAreDetails set title=@title,subtitle=@subtitle,description1=@description1,description2=@description2 where Id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("title", updateWhoWeAreDTO.Title);
            parameters.Add("id", updateWhoWeAreDTO.Id);
            parameters.Add("subTitle", updateWhoWeAreDTO.SubTitle);
            parameters.Add("description1", updateWhoWeAreDTO.Description1);
            parameters.Add("description2", updateWhoWeAreDTO.Description2);

            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
