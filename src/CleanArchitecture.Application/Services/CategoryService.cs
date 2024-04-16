using AutoMapper;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Requests.Category;
using CleanArchitecture.Application.Results;
using CleanArchitecture.Application.ViewModels;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Notifications;

namespace CleanArchitecture.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Result> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();

            if (categories == null)
                return new Result(404, $"Não foram encontradas categorias.", false);

            var model = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
            var result = new Result(200, $"Requisição realizada com sucesso", true);
            result.SetData(model);

            return result;
        }

        public async Task<Result> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            if (category == null)
                return new Result(404, $"Não foram encontradas categorias vinculados a esse Id.", false);

            var model = _mapper.Map<CategoryViewModel>(category);
            var result = new Result(200, $"Requisição realizada com sucesso", true);
            result.SetData(model);

            return result;
        }

        public async Task<Result> CreateAsync(CreateCategoryRequest request)
        {
            var category = _mapper.Map<Category>(request);
            Result result;
            if (category.Validate())
            {
                try
                {
                    await _categoryRepository.CreateAsync(category);
                    result = new Result(200, $"Categoria {category.Name} criada com sucesso", true);
                    var data = _mapper.Map<CategoryViewModel>(category);
                    result.SetData(data);
                    return result;
                }
                catch (Exception ex)
                {
                    result = new Result(500, $"Falha interna do servidor, detalhes: {ex.Message}", false);
                    return result;
                }

            }

            result = new Result(400, $"Falha ao criar categoria {category.Name} na base de dados, verifique os campos e tente novamente.", false);
            result.SetNotifications(category.Notifications as List<Notification>);
            return result;
        }

        public async Task<Result> UpdateAsync(UpdateCategoryRequest request)
        {
            var category = _mapper.Map<Category>(request);
            Result result;
            if (category.Validate())
            {
                try
                {
                    await _categoryRepository.UpdateAsync(category);
                    result = new Result(200, $"Categoria {category.Name} atualizada com sucesso", true);
                    var data = _mapper.Map<CategoryViewModel>(category);
                    result.SetData(data);
                    return result;
                }
                catch (Exception ex)
                {
                    result = new Result(500, $"Falha interna do servidor, detalhes: {ex.Message}", false);
                    return result;
                }

            }

            result = new Result(400, $"Falha ao atualizar categoria {category.Name} na base de dados, verifique os campos e tente novamente.", false);
            result.SetNotifications(category.Notifications as List<Notification>);
            return result;
        }

        public async Task<Result> RemoveAsync(int id)
        {
            try
            {
                var category = await _categoryRepository.GetByIdAsync(id);

                if (category == null)
                    return new Result(404, "Não foram encontrados categorias com esse ID", false);

                await _categoryRepository.RemoveAsync(category);
                return new Result(200, "Categoria apagada com sucesso", true);
            }
            catch (Exception ex)
            {
                return new Result(500, $"Erro interno ao tentar apagar categoria. Mais detalhes: {ex.Message}", false);
            }
        }

    }
}
