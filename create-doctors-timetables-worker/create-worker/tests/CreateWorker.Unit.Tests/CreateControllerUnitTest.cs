using CreateController;
using CreateEntitys;
using CreateInterface.Gateway.Cache;
using CreateInterface.Gateway.DB;
using CreateInterface.UseCase;
using Moq;

namespace UsersWorkerCreate.Unit.Tests
{
    public class CreateControllerUnitTest
    {
        [Fact]
        public async Task When_CreateController_Ok()
        {
            Mock<ICreateDoctorTimetablesUseCase> createDoctorTimetablesUseCase = new();

            var cache = new Mock<ICacheGateway<DoctorTimetablesDateEntity>>();

            Mock<IDoctorTimetablesDateDBGateway> doctorTimetablesDateDbGateway = new();
            Mock<IDoctorTimetablesTimeDBGateway> doctorTimetablesTimeDbGateway = new();


            createDoctorTimetablesUseCase
                .Setup(s => s .Create(It.IsAny<DoctorTimetablesDateEntity>()))
                .Returns(new Presenters.CreateResult<DoctorTimetablesDateEntity>
                {
                    Data = new DoctorTimetablesDateEntity
                    {
                        AvailableDate = DateTime.Now,
                        CreateDate = DateTime.Now,
                        Id = "a",
                        IdDoctor = "a",
                        DoctorTimetablesTimes = new List<DoctorTimetablesTimeEntity>
                        {
                            new DoctorTimetablesTimeEntity
                            {
                                Id = "a",
                                CreateDate = DateTime.Now,
                                Time = "09:00",
                                IdDoctorsTimetablesDate = "a"
                            }
                        }
                    }                   
                });

            var controller = new CreateDoctorTimetablesController(
                createDoctorTimetablesUseCase.Object,
                cache.Object,
                doctorTimetablesDateDbGateway.Object,
                doctorTimetablesTimeDbGateway.Object
                );

            var dto = new DoctorTimetablesDateEntity
            {
                AvailableDate = DateTime.Now,
                CreateDate = DateTime.Now,
                Id = "a",
                IdDoctor = "b",
                DoctorTimetablesTimes = new List<DoctorTimetablesTimeEntity>
                {
                    new DoctorTimetablesTimeEntity
                    {
                        CreateDate = DateTime.Now,
                        Id = "c",
                        Time = "10:00",
                        IdDoctorsTimetablesDate = "b"
                    }
                }
            };

           var result = await controller.CreateAsync(dto);

            Assert.True(result.Success);
        }

        [Fact]
        public async Task When_CreateController_Error()
        {
            Mock<ICreateDoctorTimetablesUseCase> createDoctorTimetablesUseCase = new();

            var cache = new Mock<ICacheGateway<DoctorTimetablesDateEntity>>();

            Mock<IDoctorTimetablesDateDBGateway> doctorTimetablesDateDbGateway = new();
            Mock<IDoctorTimetablesTimeDBGateway> doctorTimetablesTimeDbGateway = new();


            createDoctorTimetablesUseCase
                .Setup(s => s.Create(It.IsAny<DoctorTimetablesDateEntity>()))
                .Returns(new Presenters.CreateResult<DoctorTimetablesDateEntity>
                {
                    Data = new DoctorTimetablesDateEntity
                    {
                        AvailableDate = DateTime.Now,
                        CreateDate = DateTime.Now,
                        Id = "a",
                        IdDoctor = "a",
                        DoctorTimetablesTimes = new List<DoctorTimetablesTimeEntity>
                        {
                            new DoctorTimetablesTimeEntity
                            {
                                Id = "a",
                                CreateDate = DateTime.Now,
                                IdDoctorsTimetablesDate = "a"
                            }
                        }
                    },
                    Errors = new List<string>
                    {
                        "Erro"
                    }
                });

            var controller = new CreateDoctorTimetablesController(
                createDoctorTimetablesUseCase.Object,
                cache.Object,
                doctorTimetablesDateDbGateway.Object,
                doctorTimetablesTimeDbGateway.Object
                );

            var dto = new DoctorTimetablesDateEntity
            {
                AvailableDate = DateTime.Now,
                CreateDate = DateTime.Now,
                Id = "a",
                IdDoctor = "b",
                DoctorTimetablesTimes = new List<DoctorTimetablesTimeEntity>
                {
                    new DoctorTimetablesTimeEntity
                    {
                        CreateDate = DateTime.Now,
                        Id = "c",
                        Time = "10:00",
                        IdDoctorsTimetablesDate = "b"
                    }
                }
            };

            await Assert.ThrowsAsync<Exception>(async () => await controller.CreateAsync(dto));
        }
    }
}
