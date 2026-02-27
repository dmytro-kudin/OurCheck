using Microsoft.EntityFrameworkCore;
using OurCheck.Application.Repositories;
using OurCheck.Domain.Entities;
using OurCheck.Infrastructure.Constants;
using OurCheck.Infrastructure.Data;

namespace OurCheck.Persistence;

public class AppointmentRepository : RepositoryBase<Appointment>, IAppointmentRepository
{
    public AppointmentRepository(AppDbContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<Appointment>> GetAllAsync()
    {
        return await DbSet
            .AsNoTracking()
            .OrderBy(x => x.AppointmentTime)
            .ToListAsync();
    }

    public override async Task<Appointment?> GetByIdAsync(Guid id)
    {
        return await DbSet
            .IgnoreQueryFilters([AppointmentQueryFilters.FutureOnly])
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}