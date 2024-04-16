using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Requests.Category;
using CleanArchitecture.Application.Results;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        [Route("GetAllCategories")]
        public async Task<Result> GetAll([FromServices] ICategoryService _service)
        {
            return await _service.GetCategoriesAsync();
        }

        [HttpGet]
        [Route("GetCategoryById/{id}")]
        public async Task<Result> GetById(int id,
            [FromServices] ICategoryService _service)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<Result> Post(CreateCategoryRequest request,
            [FromServices] ICategoryService _service)
        {
            return await _service.CreateAsync(request); 
        }

        [HttpPut]
        [Route("UpdateCategory")]
        public async Task<Result> Put(UpdateCategoryRequest request,
            [FromServices] ICategoryService _service)
        {
            return await _service.UpdateAsync(request);
        }

        [HttpDelete]
        [Route("DeleteCategory/{id}")]
        public async Task<Result> Delete(int id, 
            [FromServices] ICategoryService _service)
        {
            return await _service.RemoveAsync(id);
        }
    }
}
