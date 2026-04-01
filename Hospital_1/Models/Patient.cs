namespace Hospital_1.Models;

public class Patient
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Gender { get; set; }

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
