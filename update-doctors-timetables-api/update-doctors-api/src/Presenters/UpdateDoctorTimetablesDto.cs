namespace Presenters;

public class UpdateDoctorTimetablesDto
{
    public string Id { get; set; }
    public List<DoctorsTimetablesTimesDto> TimeList { get; set; }
}