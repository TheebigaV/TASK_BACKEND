using Microsoft.EntityFrameworkCore;
using Hospital_1.Data;
using Hospital_1.Models;
using Hospital_1.DTOs;

namespace Hospital_1.Services;

public class HospitalService : IHospitalService
{
    private readonly HospitalDbContext _context;

    public HospitalService(HospitalDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync()
    {
        return await _context.Doctors
            .Include(d => d.Specialization)
            .Select(d => new DoctorDto {
                Id = d.Id,
                Name = d.Name ?? string.Empty,
                Email = d.Email ?? string.Empty,
                SpecializationName = d.Specialization != null ? (d.Specialization.Name ?? string.Empty) : string.Empty,
                Skills = d.Skills ?? string.Empty
            }).ToListAsync();
    }

    public async Task<DoctorDto?> GetDoctorByIdAsync(int id)
    {
        var d = await _context.Doctors
            .Include(d => d.Specialization)
            .FirstOrDefaultAsync(x => x.Id == id);
            
        if (d == null) return null;

        return new DoctorDto {
            Id = d.Id,
            Name = d.Name ?? string.Empty,
            Email = d.Email ?? string.Empty,
            SpecializationName = d.Specialization != null ? (d.Specialization.Name ?? string.Empty) : string.Empty,
            Skills = d.Skills ?? string.Empty
        };
    }

    public async Task<DoctorDto> AddDoctorAsync(CreateDoctorDto dto)
    {
        var doctor = new Doctor {
            Name = dto.Name,
            Email = dto.Email,
            SpecializationId = dto.SpecializationId,
            Skills = dto.Skills
        };
        
        _context.Doctors.Add(doctor);
        await _context.SaveChangesAsync();
        
        return (await GetDoctorByIdAsync(doctor.Id))!;
    }

    public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByDoctorIdAsync(int doctorId)
    {
        return await _context.Appointments
            .Include(a => a.Patient)
            .Include(a => a.Doctor)
            .Where(a => a.DoctorId == doctorId)
            .Select(a => new AppointmentDto {
                Id = a.Id,
                PatientName = a.Patient != null ? (a.Patient.Name ?? string.Empty) : string.Empty,
                AppointmentDate = a.AppointmentDate,
                DoctorName = a.Doctor != null ? (a.Doctor.Name ?? string.Empty) : string.Empty,
                Status = a.Status ?? string.Empty
            }).ToListAsync();
    }

    public async Task<AppointmentDto> BookAppointmentAsync(CreateAppointmentDto dto)
    {
        var appointment = new Appointment {
            PatientId = dto.PatientId,
            AppointmentDate = dto.AppointmentDate,
            DoctorId = dto.DoctorId
        };
        
        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync();
        
        var details = await _context.Appointments
            .Include(a => a.Patient)
            .Include(a => a.Doctor)
            .FirstOrDefaultAsync(a => a.Id == appointment.Id);
            
        return new AppointmentDto {
            Id = appointment.Id,
            PatientName = details?.Patient?.Name ?? "Unknown",
            AppointmentDate = appointment.AppointmentDate,
            DoctorName = details?.Doctor?.Name ?? "Unknown",
            Status = appointment.Status ?? string.Empty
        };
    }

    public async Task<IEnumerable<SpecializationDto>> GetSpecializationsAsync()
    {
        return await _context.Specializations.Select(s => new SpecializationDto {
            Id = s.Id,
            Name = s.Name ?? string.Empty,
            Description = s.Description ?? string.Empty
        }).ToListAsync();
    }

    public async Task<SpecializationDto> AddSpecializationAsync(string name, string description)
    {
        var spec = new Specialization { Name = name, Description = description };
        _context.Specializations.Add(spec);
        await _context.SaveChangesAsync();
        return new SpecializationDto {
            Id = spec.Id,
            Name = spec.Name,
            Description = spec.Description
        };
    }

    public async Task<PatientDto> RegisterPatientAsync(CreatePatientDto dto)
    {
        var patient = new Patient {
            Name = dto.Name,
            Email = dto.Email,
            Phone = dto.Phone,
            DateOfBirth = dto.DateOfBirth,
            Gender = dto.Gender
        };
        
        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();
        
        return new PatientDto {
            Id = patient.Id,
            Name = patient.Name,
            Email = patient.Email,
            Phone = patient.Phone
        };
    }

    public async Task<IEnumerable<PatientDto>> GetAllPatientsAsync()
    {
        return await _context.Patients
            .Select(p => new PatientDto {
                Id = p.Id,
                Name = p.Name ?? string.Empty,
                Email = p.Email ?? string.Empty,
                Phone = p.Phone ?? string.Empty
            }).ToListAsync();
    }
}
