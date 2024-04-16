using CleanArchitecture.Application.Requests.Product;
using CleanArchitecture.Application.Results;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IProductService
    {
        Task<Result> GetProductsAsync();
        Task<Result> GetByIdAsync(int id);
        Task<Result> CreateAsync(CreateProductRequest request);
        Task<Result> UpdateAsync(UpdateProductRequest request);
        Task<Result> RemoveAsync(int id);
    }
}
