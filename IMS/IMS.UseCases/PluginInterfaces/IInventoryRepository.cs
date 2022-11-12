using IMS.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.PluginInterfaces;
public interface IInventoryRepository
{
    Task<Inventory?> GetInventoryByIdAsync(int inventoryUd);
    Task UpdateInventoryAsync(Inventory inventory);
    Task AddInventoryAsync(Inventory inventory);
    Task<IEnumerable<Inventory>> GetInventoryByName(string name);
}
