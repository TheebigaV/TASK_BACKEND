using Microsoft.AspNetCore.Mvc;
using Hospital_1.Services;
using Hospital_1.DTOs;

namespace Hospital_1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HospitalController : ControllerBase
{
    private readonly IHospitalService _hospitalService;

    public HospitalController(IHospitalService hospitalService)
    {
        _hospitalService = hospitalService;
    }

    [HttpGet("doctors")]
    public async Task<IActionResult> GetDoctors() => Ok(await _hospitalService.GetAllDoctorsAsync());

    [HttpGet("doctors/{id}")]
    public async Task<IActionResult> GetDoctor(int id) 
    {
        var doctor = await _hospitalService.GetDoctorByIdAsync(id);
        return doctor == null ? NotFound() : Ok(doctor);
    }

    [HttpPost("doctors")]
    public async Task<IActionResult> AddDoctor(CreateDoctorDto dto) => Ok(await _hospitalService.AddDoctorAsync(dto));

    [HttpGet("doctors/{id}/appointments")]
    public async Task<IActionResult> GetDoctorAppointments(int id) => Ok(await _hospitalService.GetAppointmentsByDoctorIdAsync(id));

    [HttpPost("appointments")]
    public async Task<IActionResult> BookAppointment(CreateAppointmentDto dto) => Ok(await _hospitalService.BookAppointmentAsync(dto));

    [HttpGet("specializations")]
    public async Task<IActionResult> GetSpecializations() => Ok(await _hospitalService.GetSpecializationsAsync());

    [HttpPost("specializations")]
    public async Task<IActionResult> AddSpecialization(CreateSpecializationDto dto) 
        => Ok(await _hospitalService.AddSpecializationAsync(dto.Name, dto.Description));

    [HttpGet("patients")]
    public async Task<IActionResult> GetPatients() => Ok(await _hospitalService.GetAllPatientsAsync());

    [HttpPost("patients")]
    public async Task<IActionResult> RegisterPatient(CreatePatientDto dto) => Ok(await _hospitalService.RegisterPatientAsync(dto));
}
