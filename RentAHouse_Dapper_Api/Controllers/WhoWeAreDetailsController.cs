using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentAHouse_Dapper_Api.DataAccess.Abstract;
using RentAHouse_Dapper_Api.DTOs.CategoryDTOs;
using RentAHouse_Dapper_Api.DTOs.WhoWeAreDTOs;

namespace RentAHouse_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreDetailsController : ControllerBase
    {
        private readonly IWhoWeAreRepository whoWeAreRepository;
        public WhoWeAreDetailsController(IWhoWeAreRepository whoWeAreRepository)
        {
            this.whoWeAreRepository = whoWeAreRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await whoWeAreRepository.GetAllAsync();

            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateWhoWeAreDTO createWhoWeAreDTO)
        {
            await whoWeAreRepository.Create(createWhoWeAreDTO);

            return Ok(new { StatusCode = 200 });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await whoWeAreRepository.Delete(id);

            return Ok(new { StatusCode = 200 });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await whoWeAreRepository.GetById(id: id);

            return Ok(value);
        }
    }
}
