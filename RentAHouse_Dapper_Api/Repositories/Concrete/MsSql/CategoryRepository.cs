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

        public async Task<List<ResultCategoryDTO>> GetAllAsync()
        {
            string query = "select *from categories";
            using (var connection = context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDTO>(query);
                return values.ToList();
            }
        }
    }
}
