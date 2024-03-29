﻿using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases;
public class SellProductUseCase : ISellProductUseCase
{
    private readonly IProductTransactionRepository _productTransactionRepository;
    private readonly IProductRepository _productRepository;

    public SellProductUseCase(IProductTransactionRepository productTransactionRepository,
        IProductRepository productRepository)
    {
        _productTransactionRepository = productTransactionRepository;
        _productRepository = productRepository;
    }

    public async Task ExecuteAsync(string salesOrderNumber, Product product, int quanity, string doneBy)
    {
        await _productTransactionRepository.SellProductAsync(salesOrderNumber, product, quanity, product.Price, doneBy);
        product.Quantity -= quanity;
        await _productRepository.UpdateProductAsync(product);
    }
}
