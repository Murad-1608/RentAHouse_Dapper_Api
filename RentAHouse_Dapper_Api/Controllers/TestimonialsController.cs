using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentAHouse_Dapper_Api.DataAccess.Abstract;
using RentAHouse_Dapper_Api.DTOs.Testimonials;

namespace RentAHouse_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialRepository testimonialRepository;
        public TestimonialsController(ITestimonialRepository testimonialRepository)
        {
            this.testimonialRepository = testimonialRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await testimonialRepository.GetAllAsync();

            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTestimonialDTO createTestimonialDTO)
        {
            await testimonialRepository.Create(createTestimonialDTO);

            return Ok(new { StatusCode = 200 });
        }
    }
}
