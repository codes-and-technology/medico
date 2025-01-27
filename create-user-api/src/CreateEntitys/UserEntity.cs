using CreateEntitys.Base;
using Presenters.Enum;

namespace CreateEntitys;

public class UserEntity : EntityBase
{
    public string Name { get; set; }
    public string DocumentNumber { get; set; }

    public string Email { get; set; }

    public int? crm { get; set; }
    public UserType UserType { get; set; }
}
