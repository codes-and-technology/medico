using AuthEntitys.Base;

namespace AuthEntitys;

public class UserEntity : EntityBase
{
    public string Name { get; set; }
    public string CPF { get; set; }
    public string Email { get; set; }

    public string CRM { get; set; }
    
    public AuthEntity Auth{get;set;}
}