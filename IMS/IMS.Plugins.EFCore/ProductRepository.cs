using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IMS.Plugins.EFCore;

public class ProductRepository : IProductRepository
{
    private readonly IMSContext _db;

    public ProductRepository(IMSContext db)
    {
        _db = db;
    }

    public async Task AddProductAsync(Product product)
    {
        if(_db.Products.Any(x => x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase)))
        {
            return;
        }

        _db.Products.Add(product);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(int productId)
    {
        var product = await _db.Products.FindAsync(productId);
        if(product is not null)
        {
            product.IsActive = false;
            await _db.SaveChangesAsync();
        }
    }

    public async Task<Product?> GetProductByIdAsync(int productId)
    {
        return await _db.Products.Include(x => x.ProductInventories)
            .ThenInclude(x => x.Inventory)
            .FirstAsync(x => x.ProductId == productId);
    }

    public async Task<List<Product>> GetProductsByNameAsync(string name)
    {
        return await _db.Products.Where(x => (x.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase) ||
                                            string.IsNullOrWhiteSpace(name)) &&
                                            x.IsActive == true).ToListAsync();
    }

    public async Task UpdateProductAsync(Product product)
    {
        if(_db.Products.Any(x => x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase)))
        {
            return;
        }

        var prod = await _db.Products.FindAsync(product.ProductId);
        if(prod is not null)
        {
            prod.ProductName = product.ProductName;
            prod.Price = prod.Price;
            prod.Quantity = product.Quantity;
            prod.ProductInventories = product.ProductInventories;

            await _db.SaveChangesAsync();
        }
    }
}
