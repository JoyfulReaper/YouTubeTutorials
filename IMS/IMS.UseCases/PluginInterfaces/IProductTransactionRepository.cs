﻿using IMS.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.PluginInterfaces;
public interface IProductTransactionRepository
{
    Task ProduceAsync(string productionNumber, Product product, int quantity, decimal price, string doneBy);
    Task SellProductAsync(string salesOrderNumber, Product product, int quanity, decimal price, string doneBy);
}