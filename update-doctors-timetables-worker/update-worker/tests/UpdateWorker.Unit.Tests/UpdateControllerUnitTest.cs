using UpdateController;
using UpdateEntitys;
using UpdateInterface.Gateway.Cache;
using UpdateInterface.Gateway.DB;
using UpdateInterface.UseCase;
using Moq;

namespace UsersWorkerUpdate.Unit.Tests
{
    public class UpdateControllerUnitTest
    {
        // [Fact]
        // public async Task When_UpdateController_Ok()
        // {
        //     Mock<IUpdateDoctorTimetablesUseCase> createDoctorTimetablesUseCase = new();
        //
        //     var cache = new Mock<ICacheGateway<DoctorTimetablesDateEntity>>();
        //
        //     Mock<IDoctorTimetablesDateDBGateway> doctorTimetablesDateDbGateway = new();
        //     Mock<IDoctorTimetablesTimeDBGateway> doctorTimetablesTimeDbGateway = new();
        //
        //
        //     createDoctorTimetablesUseCase
        //         .Setup(s => s .Update(It.IsAny<DoctorTimetablesDateEntity>()))
        //         .Returns(new Presenters.UpdateResult<DoctorTimetablesDateEntity>
        //         {
        //             Data = new DoctorTimetablesDateEntity
        //             {
        //                 AvailableDate = DateTime.Now,
        //                 UpdateDate = DateTime.Now,
        //                 Id = "a",
        //                 IdDoctor = "a",
        //                 DoctorTimetablesTimes = new List<DoctorTimetablesTimeEntity>
        //                 {
        //                     new DoctorTimetablesTimeEntity
        //                     {
        //                         Id = "a",
        //                         UpdateDate = DateTime.Now,
        //                         Time = "09:00",
        //                         IdDoctorsTimetablesDate = "a"
        //                     }
        //                 }
        //             }                   
        //         });
        //
        //     var controller = new UpdateDoctorTimetablesController(
        //         createDoctorTimetablesUseCase.Object,
        //         cache.Object,
        //         doctorTimetablesDateDbGateway.Object,
        //         doctorTimetablesTimeDbGateway.Object
        //         );
        //
        //     var dto = new DoctorTimetablesDateEntity
        //     {
        //         AvailableDate = DateTime.Now,
        //         UpdateDate = DateTime.Now,
        //         Id = "a",
        //         IdDoctor = "b",
        //         DoctorTimetablesTimes = new List<DoctorTimetablesTimeEntity>
        //         {
        //             new DoctorTimetablesTimeEntity
        //             {
        //                 UpdateDate = DateTime.Now,
        //                 Id = "c",
        //                 Time = "10:00",
        //                 IdDoctorsTimetablesDate = "b"
        //             }
        //         }
        //     };
        //
        //    var result = await controller.UpdateAsync(dto);
        //
        //     Assert.True(result.Success);
        // }
        //
        // [Fact]
        // public async Task When_UpdateController_Error()
        // {
        //     Mock<IUpdateDoctorTimetablesUseCase> createDoctorTimetablesUseCase = new();
        //
        //     var cache = new Mock<ICacheGateway<DoctorTimetablesDateEntity>>();
        //
        //     Mock<IDoctorTimetablesDateDBGateway> doctorTimetablesDateDbGateway = new();
        //     Mock<IDoctorTimetablesTimeDBGateway> doctorTimetablesTimeDbGateway = new();
        //
        //
        //     createDoctorTimetablesUseCase
        //         .Setup(s => s.Update(It.IsAny<DoctorTimetablesDateEntity>()))
        //         .Returns(new Presenters.UpdateResult<DoctorTimetablesDateEntity>
        //         {
        //             Data = new DoctorTimetablesDateEntity
        //             {
        //                 AvailableDate = DateTime.Now,
        //                 UpdateDate = DateTime.Now,
        //                 Id = "a",
        //                 IdDoctor = "a",
        //                 DoctorTimetablesTimes = new List<DoctorTimetablesTimeEntity>
        //                 {
        //                     new DoctorTimetablesTimeEntity
        //                     {
        //                         Id = "a",
        //                         UpdateDate = DateTime.Now,
        //                         IdDoctorsTimetablesDate = "a"
        //                     }
        //                 }
        //             },
        //             Errors = new List<string>
        //             {
        //                 "Erro"
        //             }
        //         });
        //
        //     var controller = new UpdateDoctorTimetablesController(
        //         createDoctorTimetablesUseCase.Object,
        //         cache.Object,
        //         doctorTimetablesDateDbGateway.Object,
        //         doctorTimetablesTimeDbGateway.Object
        //         );
        //
        //     var dto = new DoctorTimetablesDateEntity
        //     {
        //         AvailableDate = DateTime.Now,
        //         UpdateDate = DateTime.Now,
        //         Id = "a",
        //         IdDoctor = "b",
        //         DoctorTimetablesTimes = new List<DoctorTimetablesTimeEntity>
        //         {
        //             new DoctorTimetablesTimeEntity
        //             {
        //                 UpdateDate = DateTime.Now,
        //                 Id = "c",
        //                 Time = "10:00",
        //                 IdDoctorsTimetablesDate = "b"
        //             }
        //         }
        //     };
        //
        //     await Assert.ThrowsAsync<Exception>(async () => await controller.UpdateAsync(dto));
        // }
    }
}
