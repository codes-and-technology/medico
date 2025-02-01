using ConsultingEntitys.Base;

namespace ConsultingEntitys;

public class DoctorsTimetablesDateEntity : EntityBase
{
    public UserEntity Doctor { get; set; }
    public DateTime AvailableDate { get; set; }
    public List<DoctorsTimetablesTimesEntity> TimeList { get; set; }
    public DateTime? DeleteDate { get; set; }
}