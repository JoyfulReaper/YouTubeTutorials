using IMS.CoreBusiness;

namespace IMS.UseCases;

public interface IViewInventoriresByNameUseCase
{
    Task<IEnumerable<Inventory>> ExecuteAsync(string name = "");
}