using IMS.CoreBusiness;

namespace IMS.UseCases;
public interface ISellProductUseCase
{
    Task ExecuteAsync(string salesOrderNumber, Product product, int quanity, string doneBy);
}