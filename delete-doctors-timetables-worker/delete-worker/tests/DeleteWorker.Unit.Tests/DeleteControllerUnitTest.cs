using DeleteController;
using DeleteEntitys;
using DeleteInterface.Gateway.Cache;
using DeleteInterface.Gateway.DB;
using DeleteInterface.UseCase;
using Moq;

namespace UsersWorkerDelete.Unit.Tests
{
    public class DeleteControllerUnitTest
    {
        // [Fact]
        // public async Task When_DeleteController_Ok()
        // {
        //     Mock<IDeleteDoctorTimetablesUseCase> createDoctorTimetablesUseCase = new();
        //
        //     var cache = new Mock<ICacheGateway<DoctorTimetablesDateEntity>>();
        //
        //     Mock<IDoctorTimetablesDateDBGateway> doctorTimetablesDateDbGateway = new();
        //     Mock<IDoctorTimetablesTimeDBGateway> doctorTimetablesTimeDbGateway = new();
        //
        //
        //     createDoctorTimetablesUseCase
        //         .Setup(s => s .Delete(It.IsAny<DoctorTimetablesDateEntity>()))
        //         .Returns(new Presenters.DeleteResult<DoctorTimetablesDateEntity>
        //         {
        //             Data = new DoctorTimetablesDateEntity
        //             {
        //                 AvailableDate = DateTime.Now,
        //                 DeleteDate = DateTime.Now,
        //                 Id = "a",
        //                 IdDoctor = "a",
        //                 DoctorTimetablesTimes = new List<DoctorTimetablesTimeEntity>
        //                 {
        //                     new DoctorTimetablesTimeEntity
        //                     {
        //                         Id = "a",
        //                         DeleteDate = DateTime.Now,
        //                         Time = "09:00",
        //                         IdDoctorsTimetablesDate = "a"
        //                     }
        //                 }
        //             }                   
        //         });
        //
        //     var controller = new DeleteDoctorTimetablesController(
        //         createDoctorTimetablesUseCase.Object,
        //         cache.Object,
        //         doctorTimetablesDateDbGateway.Object,
        //         doctorTimetablesTimeDbGateway.Object
        //         );
        //
        //     var dto = new DoctorTimetablesDateEntity
        //     {
        //         AvailableDate = DateTime.Now,
        //         DeleteDate = DateTime.Now,
        //         Id = "a",
        //         IdDoctor = "b",
        //         DoctorTimetablesTimes = new List<DoctorTimetablesTimeEntity>
        //         {
        //             new DoctorTimetablesTimeEntity
        //             {
        //                 DeleteDate = DateTime.Now,
        //                 Id = "c",
        //                 Time = "10:00",
        //                 IdDoctorsTimetablesDate = "b"
        //             }
        //         }
        //     };
        //
        //    var result = await controller.DeleteAsync(dto);
        //
        //     Assert.True(result.Success);
        // }
        //
        // [Fact]
        // public async Task When_DeleteController_Error()
        // {
        //     Mock<IDeleteDoctorTimetablesUseCase> createDoctorTimetablesUseCase = new();
        //
        //     var cache = new Mock<ICacheGateway<DoctorTimetablesDateEntity>>();
        //
        //     Mock<IDoctorTimetablesDateDBGateway> doctorTimetablesDateDbGateway = new();
        //     Mock<IDoctorTimetablesTimeDBGateway> doctorTimetablesTimeDbGateway = new();
        //
        //
        //     createDoctorTimetablesUseCase
        //         .Setup(s => s.Delete(It.IsAny<DoctorTimetablesDateEntity>()))
        //         .Returns(new Presenters.DeleteResult<DoctorTimetablesDateEntity>
        //         {
        //             Data = new DoctorTimetablesDateEntity
        //             {
        //                 AvailableDate = DateTime.Now,
        //                 DeleteDate = DateTime.Now,
        //                 Id = "a",
        //                 IdDoctor = "a",
        //                 DoctorTimetablesTimes = new List<DoctorTimetablesTimeEntity>
        //                 {
        //                     new DoctorTimetablesTimeEntity
        //                     {
        //                         Id = "a",
        //                         DeleteDate = DateTime.Now,
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
        //     var controller = new DeleteDoctorTimetablesController(
        //         createDoctorTimetablesUseCase.Object,
        //         cache.Object,
        //         doctorTimetablesDateDbGateway.Object,
        //         doctorTimetablesTimeDbGateway.Object
        //         );
        //
        //     var dto = new DoctorTimetablesDateEntity
        //     {
        //         AvailableDate = DateTime.Now,
        //         DeleteDate = DateTime.Now,
        //         Id = "a",
        //         IdDoctor = "b",
        //         DoctorTimetablesTimes = new List<DoctorTimetablesTimeEntity>
        //         {
        //             new DoctorTimetablesTimeEntity
        //             {
        //                 DeleteDate = DateTime.Now,
        //                 Id = "c",
        //                 Time = "10:00",
        //                 IdDoctorsTimetablesDate = "b"
        //             }
        //         }
        //     };
        //
        //     await Assert.ThrowsAsync<Exception>(async () => await controller.DeleteAsync(dto));
        // }
    }
}
