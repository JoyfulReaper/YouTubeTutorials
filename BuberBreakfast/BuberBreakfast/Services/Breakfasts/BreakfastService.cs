using BuberBreakfast.Models;
using BuberBreakfast.Persistence;
using BuberBreakfast.ServiceErrors;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace BuberBreakfast.Services.Breakfasts;

public class BreakfastService : IBreakfastService
{
    private readonly BuberBreakfastDbContext _dbContext;

    public BreakfastService(BuberBreakfastDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ErrorOr<Created> CreateBreakfast(Breakfast breakfast)
    {
        _dbContext.Add(breakfast);
        _dbContext.SaveChanges();

        return Result.Created;
    }

    public ErrorOr<Deleted> DeleteBreakfast(Guid id)
    {
        var breakfast = _dbContext.Breakfasts.Find(id);
        if (breakfast == null)
        {
            return Errors.Breakfast.NotFound;
        }

        _dbContext.Remove(breakfast);
        _dbContext.SaveChanges();

        return Result.Deleted;
    }

    public ErrorOr<Breakfast> GetBreakfast(Guid id)
    {
        if (_dbContext.Breakfasts.Find(id) is Breakfast breakfast)
        {
            return breakfast;
        }

        return Errors.Breakfast.NotFound;
    }
    
    public ErrorOr<UpsertedBreakfast> UpsertBreakfast(Breakfast breakfast)
    {
        var isNewlyCreated = !_dbContext.Breakfasts
            .Any(b => b.Id == breakfast.Id);

        if (isNewlyCreated)
        {
            _dbContext.Add(breakfast);
        }
        else
        {
            _dbContext.Update(breakfast);
        }
        _dbContext.SaveChanges();

        return new UpsertedBreakfast(isNewlyCreated);
    }
}