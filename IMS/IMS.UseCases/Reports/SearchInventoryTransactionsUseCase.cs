using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Reports;
public class SearchInventoryTransactionsUseCase : ISearchInventoryTransactionsUseCase
{
    private readonly IInventoryTransactionRepository _inventoryTransactionRepository;

    public SearchInventoryTransactionsUseCase(IInventoryTransactionRepository inventoryTransactionRepository)
    {
        _inventoryTransactionRepository = inventoryTransactionRepository;
    }

    public async Task<IEnumerable<InventoryTransaction>> ExecuteAsync(
        string inventoryName,
        DateTime? dateFrom,
        DateTime? dateTo,
        InventoryTransactionType? transactionType
        )
    {
        return await _inventoryTransactionRepository.GetInventoryTransactionsAsync(inventoryName, dateFrom, dateTo, transactionType);
    }
}
