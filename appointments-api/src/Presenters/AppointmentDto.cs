namespace Presenters;

public class AppointmentReportDto
{
    public string Id { get; set; }
    public string Status { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? DeleteDate { get; set; }
    public DoctorReportDto Doctor { get; set; }
    public PatientReportDto Patient { get; set; }
    public DateReportDto Date { get; set; }
    public TimeReportDto Time { get; set; }
}

public class DoctorReportDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string CPF { get; set; }
    public string Email { get; set; }
    public string CRM { get; set; }
    public DateTime CreateDate { get; set; }
    public decimal? Amount { get; set; }
    public string Specialty { get; set; }
    public int? Score { get; set; }
}

public class PatientReportDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string CPF { get; set; }
    public string Email { get; set; }
    public string CRM { get; set; }
    public DateTime CreateDate { get; set; }
    public decimal? Amount { get; set; }
    public string Specialty { get; set; }
    public int? Score { get; set; }
}

public class DateReportDto
{
    public string Id { get; set; }
    public string IdDoctor { get; set; }
    public DateTime AvailableDate { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? DeleteDate { get; set; }
}

public class TimeReportDto
{
    public string Id { get; set; }
    public string IdDoctorsTimetablesDate { get; set; }
    public string Time { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? DeleteDate { get; set; }
}
