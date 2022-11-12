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

    public async Task<List<Product>> GetProductsByName(string name)
    {
        return await _db.Products.Where(x => x.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase) ||
                                            string.IsNullOrWhiteSpace(name)).ToListAsync();
    }
}
