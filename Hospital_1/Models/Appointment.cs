namespace Hospital_1.Models;

public class Appointment
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;
    public DateTime AppointmentDate { get; set; }
    public string Status { get; set; } = "Scheduled";
    
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; } = null!;
}
