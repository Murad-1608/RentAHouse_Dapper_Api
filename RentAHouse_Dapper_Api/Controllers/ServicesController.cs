using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentAHouse_Dapper_Api.DataAccess.Abstract;
using RentAHouse_Dapper_Api.DTOs.ServiceDTOs;

namespace RentAHouse_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepository serviceRepository;
        public ServicesController(IServiceRepository serviceRepository)
        {
            this.serviceRepository = serviceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await serviceRepository.GetAllAsync();

            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceDTO create)
        {
            await serviceRepository.Create(create);

            return Ok(new { StatusCode = 200 });
        }
    }
}
