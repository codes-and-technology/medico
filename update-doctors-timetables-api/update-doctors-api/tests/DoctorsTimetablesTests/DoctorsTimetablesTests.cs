using UpdateController;
using UpdateInterface;
using Moq;
using Presenters;

namespace UpdateTests;

public class UpdateDoctorsTests
{
    [Fact]
    public async Task When_UpdateDoctorTimetables_Ok()
    {
        Mock<IDoctorTimetablesConsultingGateway> doctorTimetablesConsultingGateway = new();
        Mock<IDoctorTimetablesQueueGateway> doctorTimetablesQueueGateway = new();

        doctorTimetablesConsultingGateway.Setup(s => s.GetAllAsync(It.IsAny<string>())).ReturnsAsync(new ConsultingDoctorTimetablesDateDto
        {
            Date = "2025-01-02",
            Id = "1",
            IdDoctor = "1",
            TimeList = new List<DoctorsTimetablesTimesDto>
            {
                new DoctorsTimetablesTimesDto
                {
                    Id = "1",
                    IdDoctorsTimetablesDate = "1",
                    Time = "07:00"
                }
            }
        });

        var controller = new UpdateDoctorController(doctorTimetablesConsultingGateway.Object, doctorTimetablesQueueGateway.Object);

        var dto = new UpdateDoctorTimetablesDto()
        {
            Id = "1",            
            TimeList = new List<TimeList>
            {
              new TimeList
              {
                  Id = "1",
                  Time = "12:00"
              }
            }
        };
        var result = await controller.UpdateDoctorAsync(dto, "sou um token", Guid.NewGuid().ToString());

        Assert.True(result.Success);
    }

    [Fact]
    public async Task When_UpdateDoctorTimetables_Error()
    {
        Mock<IDoctorTimetablesConsultingGateway> doctorTimetablesConsultingGateway = new();
        Mock<IDoctorTimetablesQueueGateway> doctorTimetablesQueueGateway = new();


        doctorTimetablesConsultingGateway.Setup(s => s.GetAllAsync(It.IsAny<string>())).ReturnsAsync(new ConsultingDoctorTimetablesDateDto { });

        var controller = new UpdateDoctorController(doctorTimetablesConsultingGateway.Object, doctorTimetablesQueueGateway.Object);

        var dto = new UpdateDoctorTimetablesDto()
        {
            Id = "1",
            TimeList = new List<TimeList>
            {
              new TimeList
              {
                  Id = "1",
                  Time = "12:00"
              }
            }
        };

        var result = await controller.UpdateDoctorAsync(dto, "sou um token", Guid.NewGuid().ToString());

        Assert.False(result.Success);
    }
}