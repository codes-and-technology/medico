namespace Presenters;

public class DeleteDoctorTimetablesDto
{
    public string Id { get; set; }
    public List<TimeList> TimeList { get; set; }
}

public class TimeList
{
    public string Id { get; set; }
    public string Time { get; set; }
}