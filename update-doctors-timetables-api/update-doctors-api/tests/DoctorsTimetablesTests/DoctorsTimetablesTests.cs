using UpdateController;
using UpdateInterface;
using Moq;
using Presenters;

namespace UpdateTests;

public class UpdateDoctorsTests
{
    // [Fact]
    // public async Task When_UpdateDoctorTimetables_Ok()
    // {
    //     Mock<IDoctorTimetablesConsultingGateway> doctorTimetablesConsultingGateway = new();
    //     Mock<IDoctorTimetablesQueueGateway> doctorTimetablesQueueGateway = new();
    //
    //     doctorTimetablesConsultingGateway.Setup(s => s.GetAllAsync(It.IsAny<string>())).ReturnsAsync(new List<ConsultingDoctorTimetablesDateDto>());
    //     
    //     var controller = new UpdateDoctorController(doctorTimetablesConsultingGateway.Object, doctorTimetablesQueueGateway.Object);
    //
    //     var dto = new UpdateDoctorTimetablesDto()
    //     {
    //         AvailableDate = DateTime.Now,
    //         Times = new List<string>
    //         {
    //             "08:00",
    //             "09:00",
    //             "10:00"
    //         }
    //     };
    //     var result = await controller.UpdateDoctorAsync(dto, "sou um token", Guid.NewGuid().ToString());
    //     
    //     Assert.True(result.Success);
    // }
    //
    // [Fact]
    // public async Task When_UpdateDoctorTimetables_Error()
    // {
    //     Mock<IDoctorTimetablesConsultingGateway> doctorTimetablesConsultingGateway = new();
    //     Mock<IDoctorTimetablesQueueGateway> doctorTimetablesQueueGateway = new();
    //     
    //     var date = DateTime.Now;
    //     var times = new List<string>
    //     {
    //         "08:00",
    //         "09:00",
    //         "10:00"
    //     };
    //     doctorTimetablesConsultingGateway.Setup(s => s.GetAllAsync(It.IsAny<string>())).ReturnsAsync(new List<ConsultingDoctorTimetablesDateDto>
    //     {
    //         new ConsultingDoctorTimetablesDateDto()
    //         {
    //             Date = "2025-02-01",
    //             TimeList = new List<DoctorsTimetablesTimesDto>
    //             {
    //                new DoctorsTimetablesTimesDto
    //                {
    //                    Id ="a" ,
    //                    Time = "10:00"
    //                },
    //                new DoctorsTimetablesTimesDto
    //                {
    //                    Id ="a" ,
    //                    Time = "11:00"
    //                }
    //             }
    //         }
    //     });
    //     
    //     var controller = new UpdateDoctorController(doctorTimetablesConsultingGateway.Object, doctorTimetablesQueueGateway.Object);
    //
    //     var dto = new UpdateDoctorTimetablesDto()
    //     {
    //         AvailableDate = date,
    //         Times = times
    //     };
    //     
    //     var result = await controller.UpdateDoctorAsync(dto, "sou um token", Guid.NewGuid().ToString());
    //     
    //     Assert.False(!result.Success);
    // }
}