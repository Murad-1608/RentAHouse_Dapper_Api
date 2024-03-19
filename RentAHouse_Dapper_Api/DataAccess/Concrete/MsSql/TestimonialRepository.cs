using Dapper;
using RentAHouse_Dapper_Api.DataAccess.Abstract;
using RentAHouse_Dapper_Api.DTOs.Testimonials;
using RentAHouse_Dapper_Api.Models.DapperContext;

namespace RentAHouse_Dapper_Api.DataAccess.Concrete.MsSql
{
    public class TestimonialRepository : BaseRepository, ITestimonialRepository
    {
        public TestimonialRepository(Context context) : base(context)
        {
        }

        public async Task Create(CreateTestimonialDTO testimonialDTO)
        {
            string query = "insert into Testimonials values(@name,@surname,@title,@comment,@status)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", testimonialDTO.Name);
            parameters.Add("@surname", testimonialDTO.Surname);
            parameters.Add("@title", testimonialDTO.Title);
            parameters.Add("@comment", testimonialDTO.Comment);
            parameters.Add("@status", true);

            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultTestimonialDTO>> GetAllAsync()
        {
            string query = "select *from Testimonials";

            using (var connection = context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultTestimonialDTO>(query);

                return values.ToList();
            }
        }
    }
}
