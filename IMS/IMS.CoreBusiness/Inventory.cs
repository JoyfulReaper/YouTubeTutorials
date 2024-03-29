﻿using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusiness;
public class Inventory
{
    public int InventoryId { get; set; }

    [Required]
    public string InventoryName { get; set; } = default!;

    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greated or equal to {1}")]
    public int Quantity { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Price must be greated or equal to {1}")]
    public decimal Price { get; set; }

    public List<ProductInventory>? ProductInventories { get; set; }
}
