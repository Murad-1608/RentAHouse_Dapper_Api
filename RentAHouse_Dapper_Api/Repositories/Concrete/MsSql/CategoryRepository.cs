using RentAHouse_Dapper_Api.DTOs.CategoryDTOs;
using RentAHouse_Dapper_Api.Models.DapperContext;
using RentAHouse_Dapper_Api.Repositories.Abstract;
using Dapper;

namespace RentAHouse_Dapper_Api.Repositories.Concrete.MsSql
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context context;
        public CategoryRepository(Context context)
        {
            this.context = context;
        }

        public async Task Create(CreateCategoryDTO categoryDTO)
        {
            string query = "insert into categories values(@categoryName,@categoryStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("categoryName", categoryDTO.Name);
            parameters.Add("categoryStatus", true);

            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async Task Delete(int id)
        {
            string query = "delete from categories where id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCategoryDTO>> GetAllAsync()
        {
            string query = "select *from categories";
            using (var connection = context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDTO>(query);
                return values.ToList();
            }
        }

        public async Task Update(UpdateCategoryDTO updateCategoryDTO)
        {
            string query = "update categories set Name=@name,Status=@status where Id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("name", updateCategoryDTO.Name);
            parameters.Add("id", updateCategoryDTO.Id);
            parameters.Add("status", updateCategoryDTO.Status);

            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }
    }
}
