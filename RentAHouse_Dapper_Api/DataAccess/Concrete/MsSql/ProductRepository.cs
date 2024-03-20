using Dapper;
using RentAHouse_Dapper_Api.DataAccess.Abstract;
using RentAHouse_Dapper_Api.DTOs.ProductDTOs;
using RentAHouse_Dapper_Api.Models.DapperContext;

namespace RentAHouse_Dapper_Api.DataAccess.Concrete.MsSql
{
    public sealed class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(Context context) : base(context)
        {
        }

        public Task Create(CreateProductDTO createProductDTO)
        {
            string query = "insert into Products values(categoryId=@categoryId,title=@title,)";
        }

        public async Task<List<ResultProductDTO>> GetAllAsync()
        {
            string query = "select *from Products";

            using (var connection = context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultProductDTO>(query);

                return result.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDTO>> GetWithCategory()
        {
            string query = "select p.Title,p.Price,p.City,p.District,p.CoverImage,p.Type,c.Name as CategoryName from Products p inner join Categories c on p.CategoryId=c.Id";

            using (var connection = context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultProductWithCategoryDTO>(query);

                return result.ToList();
            }
        }
    }
}
