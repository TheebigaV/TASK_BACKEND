namespace Hospital_1.Models;

public class Doctor
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Skills { get; set; } = string.Empty;
    
    public int SpecializationId { get; set; }
    public Specialization Specialization { get; set; } = null!;
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
