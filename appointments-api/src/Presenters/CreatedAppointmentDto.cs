﻿namespace Presenters;

public class CreatedAppointmentDto
{
    public string Id { get; set; }
    public string IdDoctor { get; set; }
    public string IdDoctorsTimetablesDate { get; set; }
    public string IdDoctorsTimetablesTime { get; set; }
    public string Status { get; set; }
    public string AppointmentDate { get; set; }
}
