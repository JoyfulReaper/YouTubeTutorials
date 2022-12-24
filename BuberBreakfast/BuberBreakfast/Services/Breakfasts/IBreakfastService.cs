namespace BuberBreakfast.Services.Breakfasts;

using System;
using BuberBreakfast.Models;

public interface IBreakfastService
{
    void CreateBreakfastAsync(Breakfast breakfast);
    Breakfast GetBreakfast(Guid id);
}