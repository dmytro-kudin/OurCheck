using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OurCheck.Application.Features.Appointment.Commands.Create;
using OurCheck.Application.Features.Appointment.Commands.Delete;
using OurCheck.Application.Features.Appointment.Commands.Update;
using OurCheck.Application.Features.Appointment.Queries.Get;
using OurCheck.Application.Features.Appointment.Queries.List;
using OurCheck.Dto.Appointment;

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
    public async Task<IResult> CreateAppointment([FromBody] CreateAppointmentDto dto)
    {
        var command = new CreateAppointmentCommand(dto.Note, dto.AppointmentTime, dto.SavedPlaceId);
        var createdDto = await mediatr.Send(command);
        if (Guid.Empty == createdDto.Id) return Results.BadRequest();
        return TypedResults.Created($"{Request.Path}/{createdDto.Id}", createdDto);
    }

    [HttpDelete("{id}")]
    public async Task<IResult> DeleteAppointment([FromRoute] Guid id)
    {
        await mediatr.Send(new DeleteAppointmentCommand(id));
        return Results.NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IResult> UpdateAppointment([FromRoute] Guid id, [FromBody] CreateAppointmentDto dto)
    {
        await mediatr.Send(new UpdateAppointmentCommand(id, dto.Note, dto.AppointmentTime, dto.SavedPlaceId));
        return Results.NoContent();
    }
}