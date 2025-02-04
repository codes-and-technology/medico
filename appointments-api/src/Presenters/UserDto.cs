namespace Presenters;

public class UserDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string CRM { get; set; }
    public decimal? Amount { get; set; }
    public string Specialty { get; set; }
    public int? PhysicianAssessment { get; set; }
}
