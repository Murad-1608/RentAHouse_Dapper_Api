using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentAHouse_Dapper_Api.DTOs.CategoryDTOs;
using RentAHouse_Dapper_Api.Repositories.Abstract;

namespace RentAHouse_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await categoryRepository.GetAllAsync();

            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDTO createCategoryDTO)
        {
            await categoryRepository.Create(createCategoryDTO);

            return Ok(new { StatusCode = 200 });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await categoryRepository.Delete(id);

            return Ok(new { StatusCode = 200 });
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDTO updateCategoryDTO)
        {
            await categoryRepository.Update(updateCategoryDTO);

            return Ok(new { StatusCode = 200 });
        }
    }
}
