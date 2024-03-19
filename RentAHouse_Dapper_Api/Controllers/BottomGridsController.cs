using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentAHouse_Dapper_Api.DataAccess.Abstract;
using RentAHouse_Dapper_Api.DTOs.BottomGridDTOS;

namespace RentAHouse_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BottomGridsController : ControllerBase
    {
        private readonly IBottomGridRepository bottomGridRepository;
        public BottomGridsController(IBottomGridRepository bottomGridRepository)
        {
            this.bottomGridRepository = bottomGridRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await bottomGridRepository.GetAllAsync();

            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBottomGridDTO createBottomGridDTO)
        {
            await bottomGridRepository.Create(createBottomGridDTO);

            return Ok(new { StatusCode = 200 });
        }
    }
}
