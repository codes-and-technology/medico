using ConsultingEntitys.Base;

namespace ConsultingEntitys;

public class DoctorsTimetablesDateEntity : EntityBase
{
    public string IdDoctor { get; set; }
    public DateTime AvailableDate { get; set; }
    public DateTime? DeleteDate { get; set; }

    public List<DoctorsTimetablesTimesEntity> TimeList { get; set; }
}