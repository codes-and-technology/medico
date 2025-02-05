using Entitys.Base;

namespace Entitys
{
    public class AppointmentEntity : EntityBase
    {
        public string IdPatient { get; set; }
        public string IdDoctor { get; set; }
        public string IdDoctorsTimetablesDate { get; set; }
        public string IdDoctorsTimetablesTime { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string Status { get; set; }
    }
}
