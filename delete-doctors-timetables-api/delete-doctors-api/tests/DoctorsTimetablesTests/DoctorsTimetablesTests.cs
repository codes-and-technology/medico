using DeleteController;
using DeleteInterface;
using Moq;
using Presenters;

namespace DeleteTests;

public class DeleteDoctorsTests
{
    [Fact]
    public async Task When_DeleteDoctorTimetables_Ok()
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

        var controller = new DeleteDoctorController(doctorTimetablesConsultingGateway.Object, doctorTimetablesQueueGateway.Object);

        var dto = new DeleteDoctorTimetablesDto()
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
        var result = await controller.DeleteDoctorAsync(dto, "sou um token", Guid.NewGuid().ToString());

        Assert.True(result.Success);
    }

    [Fact]
    public async Task When_DeleteDoctorTimetables_Error()
    {
        Mock<IDoctorTimetablesConsultingGateway> doctorTimetablesConsultingGateway = new();
        Mock<IDoctorTimetablesQueueGateway> doctorTimetablesQueueGateway = new();


        doctorTimetablesConsultingGateway.Setup(s => s.GetAllAsync(It.IsAny<string>())).ReturnsAsync(new ConsultingDoctorTimetablesDateDto { });

        var controller = new DeleteDoctorController(doctorTimetablesConsultingGateway.Object, doctorTimetablesQueueGateway.Object);

        var dto = new DeleteDoctorTimetablesDto()
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

        var result = await controller.DeleteDoctorAsync(dto, "sou um token", Guid.NewGuid().ToString());

        Assert.False(result.Success);
    }
}