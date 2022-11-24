using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.EFCore;
public class ProductTransactionRepository : IProductTransactionRepository
{
    private readonly IMSContext _db;
    private readonly IProductRepository _productRepository;

    public ProductTransactionRepository(IMSContext db, IProductRepository productRepository)
    {
        _db = db;
        _productRepository = productRepository;
    }

    public async Task ProduceAsync(string productionNumber, Product product, int quantity, decimal price, string doneBy)
    {
        var prod = await _productRepository.GetProductByIdAsync(product.ProductId);

        if (prod is not null)
        {
            foreach(var pi in prod.ProductInventories)
            {
                int qtyBefore = pi.Inventory.Quantity;
                pi.Inventory.Quantity -= quantity * pi.InventoryQuantity;

                _db.InventoryTransactions.Add(new InventoryTransaction
                {
                    ProductionNumber = productionNumber,
                    InventoryId = pi.Inventory.InventoryId,
                    QuantityBefore = qtyBefore,
                    ActivityType = InventoryTransactionType.ProduceProduct,
                    QuantityAfter = pi.Inventory.Quantity,
                    TransactionDate = DateTime.Now,
                    DoneBy = doneBy,
                    UnitPrice = price
                });

            }
        }

        _db.ProductTransactions.Add(new ProductTransaction
        {
            ProductionNumber = productionNumber,
            ProductId = product.ProductId,
            QuantityBefore = product.Quantity,
            ActivityType = ProductTransactionType.ProduceProduct,
            QuantityAfter = product.Quantity + quantity,
            TransactionDate = DateTime.Now,
            DoneBy = doneBy,
            UnitPrice = price
        });

        await _db.SaveChangesAsync();
    }

    public async Task SellProductAsync(string salesOrderNumber, Product product, int quanity, decimal price, string doneBy)
    {
        _db.ProductTransactions.Add(new ProductTransaction
        {
            SalesOrderNumber = salesOrderNumber,
            ProductId = product.ProductId,
            QuantityBefore = product.Quantity,
            QuantityAfter = product.Quantity - quanity,
            TransactionDate = DateTime.Now,
            DoneBy = doneBy,
            UnitPrice = price
        });
        await _db.SaveChangesAsync();
    }
}
