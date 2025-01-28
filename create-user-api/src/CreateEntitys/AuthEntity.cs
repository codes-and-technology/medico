using CreateEntitys.Base;

namespace CreateEntitys;

public class AuthEntity : EntityBase
{
    public string IdUser {get; set;}
    public string Password { get; set; }
    public DateTime LastLoginDate { get; set; }
}