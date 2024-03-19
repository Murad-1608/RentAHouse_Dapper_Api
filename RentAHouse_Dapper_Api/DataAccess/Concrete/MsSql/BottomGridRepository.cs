using Dapper;
using RentAHouse_Dapper_Api.DataAccess.Abstract;
using RentAHouse_Dapper_Api.DTOs.BottomGridDTOS;
using RentAHouse_Dapper_Api.Models.DapperContext;

namespace RentAHouse_Dapper_Api.DataAccess.Concrete.MsSql
{
    public class BottomGridRepository : BaseRepository, IBottomGridRepository
    {
        public BottomGridRepository(Context context) : base(context)
        {
        }

        public async Task Create(CreateBottomGridDTO BottomGridDTO)
        {
            string query = "insert into BottomGrids values(@icon,@title,@description)";
            var parameters = new DynamicParameters();
            parameters.Add("@icon", BottomGridDTO.Icon);
            parameters.Add("@title", BottomGridDTO.Title);
            parameters.Add("@description", BottomGridDTO.Description);

            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task Delete(int id)
        {
            string query = $"delete from BottomGrids where id={id}";

            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query);
            }
        }

        public async Task<List<ResultBottomGridDTO>> GetAllAsync()
        {
            string query = "select *from BottomGrids";

            using (var connection = context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultBottomGridDTO>(query);

                return values.ToList();
            }
        }

        public async Task<ResultBottomGridDTO> GetById(int id)
        {
            string query = $"select *from BottomGrid where id={id}";

            using (var connection = context.CreateConnection())
            {
                var values = await connection.QueryFirstAsync<ResultBottomGridDTO>(query);

                return values;
            }
        }

        public async Task Update(UpdateBottomGridDTO updateBottomGridDTO)
        {
            string query = "update BottomGrids set icon=@icon,title=@title,description=@description where id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@icon", updateBottomGridDTO.Icon);
            parameters.Add("@title", updateBottomGridDTO.Title);
            parameters.Add("@description", updateBottomGridDTO.Description);
            parameters.Add("@id", updateBottomGridDTO.Id);

            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
