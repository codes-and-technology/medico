using ConsultingEntitys.Base;

namespace ConsultingEntitys;

public class UserEntity : EntityBase
{
    public string Name { get; set; }
    public string CPF { get; set; }
    public string Email { get; set; }
    public string CRM { get; set; }
}