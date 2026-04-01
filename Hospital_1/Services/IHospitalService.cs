using Hospital_1.DTOs;

namespace Hospital_1.Services;

public interface IHospitalService
{
    Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync();
    Task<DoctorDto?> GetDoctorByIdAsync(int id);
    Task<DoctorDto> AddDoctorAsync(CreateDoctorDto doctorDto);
    
    Task<IEnumerable<AppointmentDto>> GetAppointmentsByDoctorIdAsync(int doctorId);
    Task<AppointmentDto> BookAppointmentAsync(CreateAppointmentDto appointmentDto);
    
    Task<IEnumerable<SpecializationDto>> GetSpecializationsAsync();
    Task<SpecializationDto> AddSpecializationAsync(string name, string description);

    Task<PatientDto> RegisterPatientAsync(CreatePatientDto patientDto);
    Task<IEnumerable<PatientDto>> GetAllPatientsAsync();
}
