namespace webform_backend.Models;

public class Skill
{
    public int SkillId { get; set; }
    public int SignUpFormId { get; set; }
    public required string Name { get; set; }
    
}