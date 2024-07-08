using CleanArchitecture.API.Tools;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Requests.Product;
using CleanArchitecture.Application.Results;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("GetAllCProducts")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(Result))]
        public async Task<IActionResult> GetAll([FromServices] IProductService _service)
        {
            return new ParseRequestResult().ParseToActionResult(await _service.GetProductsAsync());
        }

        [HttpGet]
        [Route("GetProductById/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(Result))]
        public async Task<IActionResult> GetById(int id,
            [FromServices] IProductService _service)
        {
            return new ParseRequestResult().ParseToActionResult(await _service.GetByIdAsync(id));
        }

        [HttpPost]
        [Route("CreateProduct")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result))]
        public async Task<IActionResult> Post(CreateProductRequest request,
            [FromServices] IProductService _service)
        {
            return new ParseRequestResult().ParseToActionResult(await _service.CreateAsync(request));
        }

        [HttpPut]
        [Route("UpdateProduct")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result))]
        public async Task<IActionResult> Put(UpdateProductRequest request,
            [FromServices] IProductService _service)
        {
            return new ParseRequestResult().ParseToActionResult(await _service.UpdateAsync(request));
        }

        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(Result))]
        public async Task<IActionResult> Delete(int id,
            [FromServices] IProductService _service)
        {
            return new ParseRequestResult().ParseToActionResult(await _service.RemoveAsync(id));
        }
    }
}
