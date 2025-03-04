using DemoCRUD.Application.ProductDTOs;
using DemoCRUD.Domain.ProductEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCRUD.Application.MappingInterface
{
    public interface IProductMapper  // Self created mapper but can use AutoMapper
    {
        ProductDto MapToDto(Product product);
        Product MapToEntity(CreateProductDto createDto);
        Product MapToEntity(UpdateProductDto updateDto);
    }
}
