namespace BuberBreakfast.Services.Breakfasts;

using System;
using BuberBreakfast.Models;
using ErrorOr;

public interface IBreakfastService
{
    void CreateBreakfastAsync(Breakfast breakfast);
    void DeleteBreakfast(Guid id);
    ErrorOr<Breakfast> GetBreakfast(Guid id);
    void UpsertBreakfast(Breakfast breakfast);
}