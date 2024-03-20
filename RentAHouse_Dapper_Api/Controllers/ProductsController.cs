using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentAHouse_Dapper_Api.DataAccess.Abstract;
using RentAHouse_Dapper_Api.DTOs.ProductDTOs;

namespace RentAHouse_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await productRepository.GetAllAsync();

            return Ok(values);
        }

        [HttpGet("GetWithCategory")]
        public async Task<IActionResult> GetWithCategory()
        {
            var values = await productRepository.GetWithCategory();

            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDTO createProductDTO)
        {

        }
    }
}
