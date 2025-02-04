using CreateEntitys.Base;
using Presenters.Enum;

namespace CreateEntitys;

public class UserEntity : EntityBase
{
    public string Name { get; set; }
    public string CPF { get; set; }
    public string Email { get; set; }

    public string CRM { get; set; }

    public decimal? Amount { get; set; } 
    public string Specialty { get; set; } 
    public int? Score { get; set; }


    public AuthEntity Auth{get;set;}
}