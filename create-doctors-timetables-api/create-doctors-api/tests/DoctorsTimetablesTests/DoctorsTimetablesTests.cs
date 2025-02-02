using CreateController;
using CreateInterface;
using Moq;
using Presenters;

namespace CreateTests;

public class CreateDoctorsTests
{
    [Fact]
    public async Task When_CreateDoctorTimetables_Ok()
    {
        Mock<IDoctorTimetablesConsultingGateway> doctorTimetablesConsultingGateway = new();
        Mock<IDoctorTimetablesQueueGateway> doctorTimetablesQueueGateway = new();

        doctorTimetablesConsultingGateway.Setup(s => s.GetAllAsync(It.IsAny<string>())).ReturnsAsync(new ConsultingDoctorTimetablesDateDto());
        
        var controller = new CreateDoctorController(doctorTimetablesConsultingGateway.Object, doctorTimetablesQueueGateway.Object);

        var dto = new CreateDoctorTimetablesDto()
        {
            AvailableDate = DateTime.Now,
            Times = new List<string>
            {
                "08:00",
                "09:00",
                "10:00"
            }
        };
        var result = await controller.CreateDoctorAsync(dto, "sou um token", Guid.NewGuid().ToString());
        
        Assert.True(result.Success);
    }
    
    [Fact]
    public async Task When_CreateDoctorTimetables_Error()
    {
        Mock<IDoctorTimetablesConsultingGateway> doctorTimetablesConsultingGateway = new();
        Mock<IDoctorTimetablesQueueGateway> doctorTimetablesQueueGateway = new();
        
        var date = DateTime.Now;
        var times = new List<string>
        {
            "08:00",
            "09:00",
            "10:00"
        };
        doctorTimetablesConsultingGateway.Setup(s => s.GetAllAsync(It.IsAny<string>())).ReturnsAsync(new ConsultingDoctorTimetablesDateDto
        {
            Date = "2025-02-01",
            TimeList = new List<DoctorsTimetablesTimesDto>
                {
                   new DoctorsTimetablesTimesDto
                   {
                       Id ="a" ,
                       Time = "10:00"
                   },
                   new DoctorsTimetablesTimesDto
                   {
                       Id ="a" ,
                       Time = "11:00"
                   }
                }
        });
        
        var controller = new CreateDoctorController(doctorTimetablesConsultingGateway.Object, doctorTimetablesQueueGateway.Object);

        var dto = new CreateDoctorTimetablesDto()
        {
            AvailableDate = date,
            Times = times
        };
        
        var result = await controller.CreateDoctorAsync(dto, "sou um token", Guid.NewGuid().ToString());
        
        Assert.False(!result.Success);
    }
}