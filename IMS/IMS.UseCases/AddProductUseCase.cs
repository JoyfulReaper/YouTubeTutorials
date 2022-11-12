using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases;
public class AddProductUseCase : IAddProductUseCase
{
    private readonly IProductRepository _productInventory;

    public AddProductUseCase(IProductRepository productInventory)
    {
        _productInventory = productInventory;
    }

    public async Task ExecuteAsync(Product product)
    {
        if (product is null)
        {
            return;
        }

        await _productInventory.AddProductAsync(product);
    }
}
