using RentAHouse_Dapper_Api.Models.DapperContext;

namespace RentAHouse_Dapper_Api.DataAccess.Concrete.MsSql
{
    public abstract class BaseRepository
    {
        protected readonly Context context;
        public BaseRepository(Context context)
        {
            this.context = context;
        }
    }
}
