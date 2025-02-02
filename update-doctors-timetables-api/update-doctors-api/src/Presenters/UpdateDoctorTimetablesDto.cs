namespace Presenters;

public class UpdateDoctorTimetablesDto
{
    public string Id { get; set; }
    public List<TimeList> TimeList { get; set; }
}

public class TimeList
{
    public string Id { get; set; }
    public string Time { get; set; }
}