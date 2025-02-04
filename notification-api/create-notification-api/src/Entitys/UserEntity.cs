using System.ComponentModel.DataAnnotations;

namespace Entitys
{
    public class UserEntity : EntityBase
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string CRM { get; set; }

        public ICollection<AppointmentEntity> Appointments { get; set; } = [];
    }
}