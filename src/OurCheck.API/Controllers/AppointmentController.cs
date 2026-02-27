using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OurCheck.API.Features.Appointment.Commands.Create;
using OurCheck.API.Features.Appointment.Commands.Delete;
using OurCheck.API.Features.Appointment.Commands.Update;
using OurCheck.API.Features.Appointment.Queries.Get;
using OurCheck.API.Features.Appointment.Queries.List;

namespace OurCheck.API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class AppointmentController(ISender mediatr) : ControllerBase
{
    [HttpGet]
    public async Task<IResult> GetAppointments()
    {
        var appointments = await mediatr.Send(new ListAppointmentsQuery());
        return TypedResults.Ok(appointments);
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetAppointmentById([FromRoute] Guid id)
    {
        var appointment = await mediatr.Send(new GetAppointmentQuery(id));
        if (appointment == null) return TypedResults.NotFound();
        return TypedResults.Ok(appointment);
    }

    [HttpPost]
    public async Task<IResult> CreateAppointment([FromBody] CreateAppointmentCommand command)
    {
        var appointmentId = await mediatr.Send(command);
        if (Guid.Empty == appointmentId) return Results.BadRequest();
        return TypedResults.Created($"{Request.Path}/{appointmentId}", new { id = appointmentId });
    }

    [HttpDelete("{id}")]
    public async Task<IResult> DeleteAppointment([FromRoute] Guid id)
    {
        await mediatr.Send(new DeleteAppointmentCommand(id));
        return Results.NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IResult> UpdateAppointment([FromRoute] Guid id, [FromBody] CreateAppointmentCommand command)
    {
        await mediatr.Send(new UpdateAppointmentCommand(id, command.Note, command.AppointmentTime, command.SavedPlaceId));
        return Results.NoContent();
    }
}