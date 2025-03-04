using DemoCRUD.Application.MappingInterface;
using DemoCRUD.Application.ProductDTOs;
using DemoCRUD.Application.UseCaseInterface;
using DemoCRUD.Domain.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCRUD.Application.UseCaseImplementation
{
    public class ProductService(IProductRepository productRepository, IProductMapper productMapper) : IProductService
    {
        public async Task AddProductAsync(CreateProductDto productDto)
        {
            var product = productMapper.MapToEntity(productDto);
            await productRepository.AddAsync(product);
        }

        public async Task DeleteProductAsync(int id) =>
            await productRepository.DeleteAsync(id);

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await productRepository.GetAllAsync();
            return products.Select(product => productMapper.MapToDto(product)).ToList();
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var product = await productRepository.GetByIdAsync(id);
            return product == null ? null : productMapper.MapToDto(product);
        }

        public async Task UpdateProductAsync(UpdateProductDto productDto)
        {
            var product = productMapper.MapToEntity(productDto);
            await productRepository.UpdateAsync(product);
        }
    }
}
