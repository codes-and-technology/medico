namespace Presenters;

public class DoctorsTimetablesDateDto
{
    public string Id { get; set; }
    public string IdDoctor { get; set; }
    public string Date { get; set; }
    public List<DoctorsTimetablesTimesDto> TimeList { get; set; }
}
