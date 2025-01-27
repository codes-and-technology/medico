using Presenters.Enum;

namespace Presenters;

public class UserConsultingDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public UserType UserType { get; set ; }
}
