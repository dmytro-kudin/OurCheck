using Microsoft.EntityFrameworkCore;
using OurCheck.Application.Services.Repositories;
using OurCheck.Domain.Entities;
using OurCheck.Infrastructure.Data;

namespace OurCheck.Persistence;

public class SavedPlaceRepository : RepositoryBase<SavedPlace>, ISavedPlaceRepository
{
    public SavedPlaceRepository(AppDbContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<SavedPlace>> GetAllAsync()
    {
        return await DbSet
            .AsNoTracking()
            .OrderByDescending(x => x.Created)
            .ToListAsync();
    }
}