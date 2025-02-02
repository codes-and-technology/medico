namespace UpdateEntitys;

public class DoctorTimetablesTimeEntity : EntityBase
{
    public string IdDoctorsTimetablesDate { get; set; }
    public string Time { get; set; }
    
    public DoctorTimetablesDateEntity DoctorTimetablesDate { get; set; }
}