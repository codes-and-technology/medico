using Entitys.Base;

namespace Entitys;

public class DoctorsTimetablesTimesEntity : EntityBase
{
    public string IdDoctorsTimetablesDate { get; set; }
    public string Time { get; set; }
    public DateTime? DeleteDate { get; set; }

    public DoctorsTimetablesDateEntity DoctorsTimetablesDate { get; set; }
}