using AutoMapper;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Requests.Product;
using CleanArchitecture.Application.Results;
using CleanArchitecture.Application.ViewModels;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Notifications;

namespace CleanArchitecture.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Result> GetProductsAsync()
        {
            var products = await _productRepository.GetProductsAsync();

            if (products == null)
                return new Result(404, $"Não foram encontrados produtos.", false);

            var model = _mapper.Map<IEnumerable<ProductViewModel>>(products);
            var result = new Result(200, $"Requisição realizada com sucesso", true);
            result.SetData(model);

            return result;
        }

        public async Task<Result> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                return new Result(404, $"Não foram encontrados produtos vinculados a esse Id.", false);

            var model = _mapper.Map<ProductViewModel>(product);
            var result = new Result(200, $"Requisição realizada com sucesso", true);
            result.SetData(model);

            return result;
        }

        public async Task<Result> CreateAsync(CreateProductRequest request)
        {
            var product = _mapper.Map<Product>(request);
            Result result;
            if (product.Validate())
            {
                try
                {
                    await _productRepository.CreateAsync(product);
                    result = new Result(200, $"Produto {product.Name} criado com sucesso", true);
                    var data = _mapper.Map<ProductViewModel>(product);
                    result.SetData(data);
                    return result;
                }
                catch (Exception ex)
                {
                    result = new Result(500, $"Falha interna do servidor, detalhes: {ex.Message}", false);
                    return result;
                }

            }

            result = new Result(400, $"Falha ao criar produto {product.Name} na base de dados, verifique os campos e tente novamente.", false);
            result.SetNotifications(product.Notifications as List<Notification>);
            return result;
        }

        public async Task<Result> UpdateAsync(UpdateProductRequest request)
        {
            var product = _mapper.Map<Product>(request);
            Result result;
            if (product.Validate())
            {
                try
                {
                    await _productRepository.UpdateAsync(product);
                    result = new Result(200, $"Produto {product.Name} atualizado com sucesso", true);
                    var data = _mapper.Map<ProductViewModel>(product);
                    result.SetData(data);
                    return result;
                }
                catch (Exception ex)
                {
                    result = new Result(500, $"Falha interna do servidor, detalhes: {ex.Message}", false);
                    return result;
                }

            }

            result = new Result(400, $"Falha ao atualizar produto {product.Name} na base de dados, verifique os campos e tente novamente.", false);
            result.SetNotifications(product.Notifications as List<Notification>);
            return result;
        }

        public async Task<Result> RemoveAsync(int id)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);

                if (product == null)
                    return new Result(404, "Não foram encontrados produtos com esse ID", false);

                await _productRepository.RemoveAsync(product);
                return new Result(200, "Produto apagado com sucesso", true);
            }
            catch (Exception ex)
            {
                return new Result(500, $"Erro interno ao tentar apagar produto. Mais detalhes: {ex.Message}", false);
            }
        }
    }
}
