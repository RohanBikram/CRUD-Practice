using DemoCRUD.Application.MappingInterface;
using DemoCRUD.Application.ProductDTOs;
using DemoCRUD.Domain.ProductEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCRUD.Application.MappingImplementation
{
    internal class ProductMapper : IProductMapper
    {
        public ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };
        }

        public Product MapToEntity(CreateProductDto createDto)
        {
            return new Product
            {
                Name = createDto.Name,
                Price = createDto.Price,
                Stock = createDto.Stock
            };
        }

        public Product MapToEntity(UpdateProductDto updateDto)
        {
            return new Product
            {
                Id = updateDto.Id,
                Name = updateDto.Name,
                Price = updateDto.Price,
                Stock = updateDto.Stock
            };
        }
    }
}
