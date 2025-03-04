using DemoCRUD.Domain.ProductEntity;
using DemoCRUD.Domain.RepositoryInterface;
using DemoCRUD.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCRUD.Infrastructure.RepositoryImplementation
{
    public class ProductRepository(AppDbContext context) : IProductRepository
    {
        public async Task AddAsync(Product product)
        {
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await context.Products.FindAsync(id);
            if (product != null)
            {
                context.Products.Remove(product);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync() =>
            await context.Products.AsNoTracking().ToListAsync();

        public async Task<Product?> GetByIdAsync(int id) =>
            await context.Products.FindAsync(id);

        public async Task UpdateAsync(Product product)
        {
            context.Products.Update(product);
            await context.SaveChangesAsync();
        }
    }
}
