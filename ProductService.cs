using HumanitarianProjectManagement.DataAccessLayer;
using HumanitarianProjectManagement.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HumanitarianProjectManagement.Services
{
    public class ProductService
    {
        private readonly HpmDbContext _context;

        public ProductService(HpmDbContext context)
        {
            _context = context;
        }

        public ProductService()
        {
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> SearchProductsAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await GetAllProductsAsync();
            }

            return await _context.Products
                .Where(p => p.Name.Contains(searchTerm) ||
                            p.SKU.Contains(searchTerm) ||
                            p.Category.Contains(searchTerm))
                .ToListAsync();
        }
    }
}
