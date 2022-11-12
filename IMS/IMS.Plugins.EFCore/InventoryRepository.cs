using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace IMS.Plugins.EFCore;
public class InventoryRepository : IInventoryRepository
{
    private readonly IMSContext _db;

    public InventoryRepository(IMSContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Inventory>> GetInventoryByName(string name)
    {
        return await _db.Inventories.Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase) ||
                                            string.IsNullOrWhiteSpace(name)).ToListAsync();
    }

    public async Task AddInventoryAsync(Inventory inventory)
    {
        if (_db.Inventories.Any(x => x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
        {
            return;
        }

        _db.Inventories.Add(inventory);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateInventoryAsync(Inventory inventory)
    {
        if(_db.Inventories.Any(x => x.InventoryId != inventory.InventoryId &&
                                x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
        {
            return;
        }

        var inv = await _db.Inventories.FindAsync(inventory.InventoryId);
        if (inv is not null)
        {
            inv.InventoryName = inventory.InventoryName;
            inv.Price = inventory.Price;
            inv.Quantity = inventory.Quantity;

            await _db.SaveChangesAsync();
        }
    }

    public async Task<Inventory?> GetInventoryByIdAsync(int inventoryId)
    {
        return await _db.Inventories.FindAsync(inventoryId);
    }
}
