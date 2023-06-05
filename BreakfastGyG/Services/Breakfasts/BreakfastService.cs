using BreakfastGyG.Models;
using BreakfastGyG.Persistence;
using BreakfastGyG.ServiceErrors;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace BreakfastGyG.Services.Breakfasts;

public class BreakfastService : IBreakfastService
{
    private readonly BreakfastGyGDbContext _dbContext;

    public BreakfastService(BreakfastGyGDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ErrorOr<List<Breakfast>> ListBreakfasts()
    {
        return _dbContext.Breakfasts.ToList();
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

        if (breakfast is null)
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
        var isNewlyCreated = !_dbContext.Breakfasts.Any(b => b.Id == breakfast.Id);
        if (isNewlyCreated)
        {
            _dbContext.Breakfasts.Add(breakfast);
        }
        else
        {
            _dbContext.Breakfasts.Update(breakfast);
        }

        _dbContext.SaveChanges();

        return new UpsertedBreakfast(isNewlyCreated);
    }
}
