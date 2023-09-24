using Microsoft.AspNetCore.Mvc;
using webform_backend.Models;

namespace webform_backend.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class SignupFormController : ControllerBase
{
    [HttpPost(Name="PostSignupForm")]
    public IActionResult PostForm(SignupForm form)
    {
        return Ok();
    }
}