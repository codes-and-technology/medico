using Presenters.Enum;

namespace Presenters;

public class UserDto
{
    public string Name { get; set; }
    public string DocumentNumber { get; set; }
    public Guid Id { get; set; }    
    public string Email { get; set; }

    public int? Crm { get; set; }
    public UserType UserType { get; set; }
    public string Password { get; set; }
}