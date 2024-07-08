using CleanArchitecture.API.Tools;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Requests.Category;
using CleanArchitecture.Application.Results;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        [Route("GetAllCategories")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(Result))]
        public async Task<IActionResult> GetAll([FromServices] ICategoryService _service)
        {
            return new ParseRequestResult().ParseToActionResult(await _service.GetCategoriesAsync());
        }

        [HttpGet]
        [Route("GetCategoryById/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(Result))]
        public async Task<IActionResult> GetById(int id,
            [FromServices] ICategoryService _service)
        {
            return  new ParseRequestResult().ParseToActionResult(await _service.GetByIdAsync(id));
        }

        [HttpPost]
        [Route("CreateCategory")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result))]
        public async Task<IActionResult> Post(CreateCategoryRequest request,
            [FromServices] ICategoryService _service)
        {
            return new ParseRequestResult().ParseToActionResult(await _service.CreateAsync(request)); 
        }

        [HttpPut]
        [Route("UpdateCategory")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result))]
        public async Task<IActionResult> Put(UpdateCategoryRequest request,
            [FromServices] ICategoryService _service)
        {
            return new ParseRequestResult().ParseToActionResult(await _service.UpdateAsync(request));
        }

        [HttpDelete]
        [Route("DeleteCategory/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(Result))]
        public async Task<IActionResult> Delete(int id, 
            [FromServices] ICategoryService _service)
        {
            return new ParseRequestResult().ParseToActionResult(await _service.RemoveAsync(id));
        }
    }
}
