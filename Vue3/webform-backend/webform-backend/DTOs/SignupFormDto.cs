namespace webform_backend.DTOs;

public record SignupForm (string Email, string Password, string? Role, List<string> Skills);