﻿using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.EFCore;
public class InventoryTransactionRepository : IInventoryTransactionRepository
{
    private readonly IMSContext _db;

    public InventoryTransactionRepository(IMSContext db)
    {
        _db = db;
    }

    public async Task PurchaseAsync(string poNumber, Inventory inventory, int quantity, decimal price, string doneBy)
    {
        _db.InventoryTransactions.Add(new InventoryTransaction
        {
            PONumber = poNumber,
            InventoryId = inventory.InventoryId,
            QuantityBefore = inventory.Quantity,
            ActivityType = InventoryTransactionType.PurchaseInventory,
            QuantityAfter = inventory.Quantity + quantity,
            TransactionDate = DateTime.Now,
            DoneBy = doneBy,
            UnitPrice = price
        });

        await _db.SaveChangesAsync();
    }
}
