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
        Mock<IDoctorTimetablesQueueGateway> doctorTimetablesQueueGateway = new();

        var controller = new DeleteDoctorController(doctorTimetablesQueueGateway.Object);

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
        Mock<IDoctorTimetablesQueueGateway> doctorTimetablesQueueGateway = new();

        var controller = new DeleteDoctorController(doctorTimetablesQueueGateway.Object);

        var dto = new DeleteDoctorTimetablesDto()
        {
            Id = "",
            TimeList = new List<TimeList>()
        };

        var result = await controller.DeleteDoctorAsync(dto, "sou um token", Guid.NewGuid().ToString());

        Assert.False(result.Success);
    }
}