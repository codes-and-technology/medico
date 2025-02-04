namespace Presenters;

public class CreateDoctorTimetablesDto
{
    public List<string> Times { get; set; }
    public DateTime AvailableDate { get; set; }
}