using OurCheck.Client.Repository.Abstract.Repositories;
using OurCheck.Client.Repository.API.Repositories.Abstract;
using OurCheck.Dto.Appointment;

namespace OurCheck.Client.Repository.API.Repositories;

public class AppointmentRepository(HttpClient httpClient) : RepositoryBase<AppointmentDto, CreateAppointmentDto>(httpClient), IAppointmentRepository
{
    protected override string FeaturePath => "api/v1/appointment";
}