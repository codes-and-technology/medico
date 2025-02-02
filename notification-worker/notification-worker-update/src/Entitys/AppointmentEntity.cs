using System.ComponentModel.DataAnnotations;

namespace Entitys;

public class AppointmentEntity : EntityBase
{
    public AppointmentEntity()
    {

    }

    public AppointmentEntity(short regionNumber)
    {
        RegionNumber = regionNumber;
    }

    [Required(ErrorMessage = "O número da região é obrigatório.")]
    [Range(11, 99, ErrorMessage = "O número da região deve estar entre 11 e 99.")]
    public short RegionNumber { get; set; }

    public ICollection<AppointmentEntity> Contacts { get; set; } = [];
}
