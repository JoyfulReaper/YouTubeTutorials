using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases;
public class ViewInventoriresByNameUseCase : IViewInventoriresByNameUseCase
{
    private readonly IInventoryRepository _inventoryRepository;

    public ViewInventoriresByNameUseCase(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }

    public async Task<IEnumerable<Inventory>> ExecuteAsync(string name = "")
    {
        return await _inventoryRepository.GetInventoryByName(name);
    }
}
