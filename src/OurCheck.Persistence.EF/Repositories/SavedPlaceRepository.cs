using Microsoft.EntityFrameworkCore;
using OurCheck.Domain.Entities;
using OurCheck.Persistence.Abstract.Repositories;
using OurCheck.Persistence.EF.Db;

namespace OurCheck.Persistence.EF.Repositories;

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