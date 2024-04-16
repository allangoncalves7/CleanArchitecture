using CleanArchitecture.Application.Requests.Category;
using CleanArchitecture.Application.Results;
using CleanArchitecture.Application.Results.Interfaces;
using CleanArchitecture.Application.ViewModels;

namespace CleanArchitecture.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<Result> GetCategoriesAsync();
        Task<Result> GetByIdAsync(int id);
        Task<Result> CreateAsync(CreateCategoryRequest request);
        Task<Result> UpdateAsync(UpdateCategoryRequest request);
        Task<Result> RemoveAsync(int id);
    }
}
