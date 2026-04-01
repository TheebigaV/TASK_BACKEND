namespace Hospital_1.DTOs;

public class SpecializationDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}

public class CreateSpecializationDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}
