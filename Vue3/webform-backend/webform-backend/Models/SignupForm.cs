namespace webform_backend.Models;

public record SignupForm (string Email, string Password, string Role, string[] Skills);