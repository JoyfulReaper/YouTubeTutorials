using IMS.CoreBusiness.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness;
public class Product
{
    public int ProductId { get; set; }

    [Required]
    public string ProductName { get; set; } = default!;

    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greated or equal to {1}")]
    public int Quantity { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Price must be greated or equal to {1}")]
    [Product_EnsurePriceIsGreaterThanInventoriesPrice]
    public decimal Price { get; set; }

    public bool IsActive { get; set; } = true;

    public List<ProductInventory>? ProductInventories { get; set; }

    public decimal TotalInventoryCost()
    {
        return ProductInventories.Sum(x => x.Inventory?.Price * x.InventoryQuantity ?? 0);
    }

    public bool ValidatePricing()
    {
        if (ProductInventories == null || ProductInventories.Count <= 0)
        {
            return true;
        }

        if(TotalInventoryCost() > Price)
        {
            return false;
        }

        return true;
    }
}
