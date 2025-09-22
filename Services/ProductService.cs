using Helloapi.Data;     // your DbContext namespace
using Helloapi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;


namespace Helloapi.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductContext _context;
        
        public ProductService(ProductContext context)
        {
            _context = context;
        }
        public async Task<Product> AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return false;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            var exisiting = await _context.Products.FindAsync(product.Id);
            if (exisiting == null)
            {
                return false;
            }
            exisiting.Name = product.Name;
            exisiting.Price = product.Price;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
