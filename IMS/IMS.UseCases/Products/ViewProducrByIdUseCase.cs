using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases;
public class ViewProducrByIdUseCase : IViewProductByIdUseCase
{
    private readonly IProductRepository _productRepository;

    public ViewProducrByIdUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product?> ExecuteAsync(int productId)
    {
        return await _productRepository.GetProductByIdAsync(productId);
    }
}
