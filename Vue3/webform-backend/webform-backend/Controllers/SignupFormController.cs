using Microsoft.AspNetCore.Mvc;
using webform_backend.Data;
using webform_backend.Models;

namespace webform_backend.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class SignupFormController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public SignupFormController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    [HttpPost(Name="PostSignupForm")]
    public IActionResult PostForm(SignupForm form)
    {
        var formToCreate = new SignupForm
        {
            Email = form.Email,
            Password = form.Password,
            Role = form.Role,
            Skills = form.Skills.Select(x => new Skill { Name = x.Name }).ToList()
        };
        
        return Ok();
    }
}