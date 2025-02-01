using ConsultingEntitys.Base;

namespace ConsultingEntitys;

public class DoctorsTimetablesTimesEntity : EntityBase
{
    public DoctorsTimetablesDateEntity Date { get; set; }
    public string Time { get; set; }
    public DateTime? DeleteDate { get; set; }
}