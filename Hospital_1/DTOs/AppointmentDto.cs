namespace Hospital_1.DTOs;

public class AppointmentDto
{
    public int Id { get; set; }
    public string PatientName { get; set; } = string.Empty;
    public DateTime AppointmentDate { get; set; }
    public string DoctorName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}

public class CreateAppointmentDto
{
    public int PatientId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public int DoctorId { get; set; }
}
