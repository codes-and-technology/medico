using ConsultingEntitys.Base;

namespace ConsultingEntitys;

public class AppointmentsEntity : EntityBase
{
    public string IdDoctor { get; set; }
    public string IdDoctorsTimetablesDate { get; set; }
    public string IdDoctorsTimetablesTime { get; set; }
}