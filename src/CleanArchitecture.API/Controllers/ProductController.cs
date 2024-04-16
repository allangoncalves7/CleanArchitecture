using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Requests.Product;
using CleanArchitecture.Application.Results;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("GetAllCProducts")]
        public async Task<Result> GetAll([FromServices] IProductService _service)
        {
            return await _service.GetProductsAsync();
        }

        [HttpGet]
        [Route("GetProductById/{id}")]
        public async Task<Result> GetById(int id,
            [FromServices] IProductService _service)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<Result> Post(CreateProductRequest request,
            [FromServices] IProductService _service)
        {
            return await _service.CreateAsync(request);
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<Result> Put(UpdateProductRequest request,
            [FromServices] IProductService _service)
        {
            return await _service.UpdateAsync(request);
        }

        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        public async Task<Result> Delete(int id,
            [FromServices] IProductService _service)
        {
            return await _service.RemoveAsync(id);
        }
    }
}
