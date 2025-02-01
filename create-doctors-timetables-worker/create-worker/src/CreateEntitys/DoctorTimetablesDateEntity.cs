namespace CreateEntitys;

public class DoctorTimetablesDateEntity : EntityBase
{
    public string IdDoctor { get; set; }
    public DateTime AvailableDate { get; set; }
    public DateTime Deletedate { get; set; }
    
    public List<DoctorTimetablesTimeEntity> DoctorTimetablesTimes { get; set; }

}