namespace UpdateEntitys;

public class DoctorTimetablesDateEntity : EntityBase
{
    public string IdDoctor { get; set; }
    
    public List<DoctorTimetablesTimeEntity> DoctorTimetablesTimes { get; set; }

}