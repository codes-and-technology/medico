using ConsultingEntitys.Base;

namespace ConsultingEntitys
{
    public class AppointmentEntity : EntityBase
    {
        public string IdPatient { get; set; }
        public string IdDoctor { get; set; }
        public string IdDoctorsTimetablesDate { get; set; }
        public string IdDoctorsTimetablesTime { get; set; }
    }
}
