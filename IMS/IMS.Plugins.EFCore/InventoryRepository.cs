﻿using IMS.CoreBusiness;
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
        _db.Inventories.Add(inventory);
        await _db.SaveChangesAsync();
    }
}