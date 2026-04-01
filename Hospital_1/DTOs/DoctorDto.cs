namespace Hospital_1.DTOs;

public class DoctorDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string SpecializationName { get; set; } = string.Empty;
    public string Skills { get; set; } = string.Empty;
}

public class CreateDoctorDto
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int SpecializationId { get; set; }
    public string Skills { get; set; } = string.Empty;
}

