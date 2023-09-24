namespace  webform_backend.Models;

public class SignupForm
{
    public int Id { get; set; }
    public required string Email { get; set; }
    public required string  Password { get; set; }
    public string? Role { get; set; }
    public ICollection<Skill> Skills { get; set; } = new List<Skill>();
}

