using Microsoft.AspNetCore.Mvc;
using webform_backend.Data;
using webform_backend.Models;
using webform_backend.DTOs;
using System.Linq;

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
    public IActionResult PostForm(DTOs.SignupForm form)
    {
        var Skills = form.Skills.Select(x => new Skill { Name = x }).ToList();
        
        var formToCreate = new Models.SignupForm
        {
            Email = form.Email,
            Password = form.Password,
            Role = form.Role,
        };

        _context.SignupForms.Add(formToCreate);
        foreach (var skill in Skills)
        {
            formToCreate.Skills.Add(skill);
        }
        _context.SaveChanges();
        
        return Ok();
    }
}