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
    private readonly IInventoryRepository _inventoryRepository;

    public PurchaseInventoryUseCase(IInventoryTransactionRepository purchaseRepository,
        IInventoryRepository inventoryRepository)
    {
        _purchaseRepository = purchaseRepository;
        _inventoryRepository = inventoryRepository;
    }

    public async Task ExecuteAsync(string poNumber, Inventory inventory, int quantity, string doneBy)
    {
        await _purchaseRepository.PurchaseAsync(poNumber, inventory, quantity, inventory.Price, doneBy);
        inventory.Quantity += quantity;
        await _inventoryRepository.UpdateInventoryAsync(inventory);
    }
}
