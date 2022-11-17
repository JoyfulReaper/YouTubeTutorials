using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases;
public class PurchaseInventoryUseCase : IPurchaseInventoryUseCase
{
    private readonly IInventoryTransactionRepository _purchaseRepository;

    public PurchaseInventoryUseCase(IInventoryTransactionRepository purchaseRepository)
    {
        _purchaseRepository = purchaseRepository;
    }

    public async Task ExecuteAsync(string poNumber, Inventory inventory, int quantity, string doneBy)
    {
        await _purchaseRepository.PurchaseAsync(poNumber, inventory, quantity, inventory.Price, doneBy);
    }
}
