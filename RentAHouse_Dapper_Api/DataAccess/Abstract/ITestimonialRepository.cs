using RentAHouse_Dapper_Api.DTOs.Testimonials;

namespace RentAHouse_Dapper_Api.DataAccess.Abstract
{
    public interface ITestimonialRepository
    {
        Task<List<ResultTestimonialDTO>> GetAllAsync();
        Task Create(CreateTestimonialDTO testimonialDTO);
    }
}
