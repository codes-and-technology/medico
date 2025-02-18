﻿using DeleteController;
using DeleteEntitys;
using DeleteInterface.Gateway.Cache;
using DeleteInterface.Gateway.DB;
using DeleteInterface.UseCase;
using DeleteUseCases.UseCase;
using Moq;
using System.Linq.Expressions;

namespace UsersWorkerDelete.Unit.Tests
{
    public class DeleteControllerUnitTest
    {
        [Fact]
        public async Task When_DeleteController_Ok()
        {
            Mock<IDeleteDoctorTimetablesUseCase> deleteDoctorTimetablesUseCase = new();

            var cache = new Mock<ICacheGateway<DoctorTimetablesDateEntity>>();

            Mock<IDoctorTimetablesDateDBGateway> doctorTimetablesDateDbGateway = new();
            Mock<IDoctorTimetablesTimeDBGateway> doctorTimetablesTimeDbGateway = new();

            doctorTimetablesDateDbGateway.Setup(s => s.FirstOrDefaultAsync(It.IsAny<Expression<Func<DoctorTimetablesDateEntity, bool>>>())).ReturnsAsync(new DoctorTimetablesDateEntity
            {
                Id = "1",
                IdDoctor = "1",

            });

            doctorTimetablesTimeDbGateway.Setup(s => s.GetAllAsync(It.IsAny<Expression<Func<DoctorTimetablesTimeEntity, bool>>>())).ReturnsAsync(new List<DoctorTimetablesTimeEntity>
            {
                new DoctorTimetablesTimeEntity
                {
                    Id = "2",
                    Time = "10:00",
                    IdDoctorsTimetablesDate = "1"
                }
            });



            deleteDoctorTimetablesUseCase.Setup(s => s
            .DeleteFullList(It.IsAny<DoctorTimetablesDateEntity>(), 
            It.IsAny<List<DoctorTimetablesTimeEntity>>(),
            It.IsAny<DoctorTimetablesDateEntity>()))
                .Returns(new Presenters.DeleteResult<DoctorTimetablesDateEntity>
                {
                    Data = new DoctorTimetablesDateEntity
                    {
                        Id = "1",
                        IdDoctor = "1",                      
                    }
                });

            deleteDoctorTimetablesUseCase
                .Setup(s => s.Delete(It.IsAny<DoctorTimetablesDateEntity>(), It.IsAny<List<DoctorTimetablesTimeEntity>>(), It.IsAny<List<DoctorTimetablesDateEntity>>()))
                .Returns(new Presenters.DeleteResult<DoctorTimetablesDateEntity>
                {
                    Data = new DoctorTimetablesDateEntity
                    {
                        DeleteDate = DateTime.Now,
                        Id = "a",
                        IdDoctor = "a",
                        DoctorTimetablesTimes = new List<DoctorTimetablesTimeEntity>
                        {
                             new DoctorTimetablesTimeEntity
                             {
                                 Id = "a",
                                 DeleteDate = DateTime.Now,
                                 Time = "09:00",
                                 IdDoctorsTimetablesDate = "a"
                             }
                        }
                    }
                });

            var controller = new DeleteDoctorTimetablesController(
                deleteDoctorTimetablesUseCase.Object,
                cache.Object,
                doctorTimetablesDateDbGateway.Object,
                doctorTimetablesTimeDbGateway.Object
                );

            var dto = new DoctorTimetablesDateEntity
            {                
                DeleteDate = DateTime.Now,
                Id = "a",
                IdDoctor = "b",
                DoctorTimetablesTimes = new List<DoctorTimetablesTimeEntity>
                 {
                     new DoctorTimetablesTimeEntity
                     {
                         DeleteDate = DateTime.Now,
                         Id = "c",
                         Time = "10:00",
                         IdDoctorsTimetablesDate = "b"
                     }
                 }
            };

            var result = await controller.DeleteAsync(dto);

            Assert.True(result.Success);
        }

        [Fact]
        public async Task When_DeleteController_Error()
        {
            Mock<IDeleteDoctorTimetablesUseCase> deleteDoctorTimetablesUseCase = new();

            var cache = new Mock<ICacheGateway<DoctorTimetablesDateEntity>>();

            Mock<IDoctorTimetablesDateDBGateway> doctorTimetablesDateDbGateway = new();
            Mock<IDoctorTimetablesTimeDBGateway> doctorTimetablesTimeDbGateway = new();
            
            doctorTimetablesDateDbGateway.Setup(s => s.FirstOrDefaultAsync(It.IsAny<Expression<Func<DoctorTimetablesDateEntity, bool>>>())).ReturnsAsync(new DoctorTimetablesDateEntity
            {
                Id = "1",
                IdDoctor = "1",

            });

            doctorTimetablesTimeDbGateway.Setup(s => s.GetAllAsync(It.IsAny<Expression<Func<DoctorTimetablesTimeEntity, bool>>>())).ReturnsAsync(new List<DoctorTimetablesTimeEntity>
            {
                new DoctorTimetablesTimeEntity
                {
                    Id = "2",
                    Time = "10:00",
                    IdDoctorsTimetablesDate = "1"
                }
            });

            deleteDoctorTimetablesUseCase
                .Setup(s => s.Delete(It.IsAny<DoctorTimetablesDateEntity>(), It.IsAny<List<DoctorTimetablesTimeEntity>>(), It.IsAny<List<DoctorTimetablesDateEntity>>()))
                .Returns(new Presenters.DeleteResult<DoctorTimetablesDateEntity>
                {
                    Data = new DoctorTimetablesDateEntity
                    {
                        DeleteDate = DateTime.Now,
                        Id = "a",
                        IdDoctor = "a",
                        DoctorTimetablesTimes = new List<DoctorTimetablesTimeEntity>
                        {
                             new DoctorTimetablesTimeEntity
                             {
                                 Id = "a",
                                 DeleteDate = DateTime.Now,
                                 IdDoctorsTimetablesDate = "a"
                             }
                        }
                    },
                    Errors = new List<string>
                    {
                         "Erro"
                    }
                });

            deleteDoctorTimetablesUseCase.Setup(s => s
       .DeleteFullList(It.IsAny<DoctorTimetablesDateEntity>(),
           It.IsAny<List<DoctorTimetablesTimeEntity>>(),
           It.IsAny<DoctorTimetablesDateEntity>()))
               .Returns(new Presenters.DeleteResult<DoctorTimetablesDateEntity>
               {
                   Errors = new List<string>
                   {
                       "Erro"
                   }
               });

            var controller = new DeleteDoctorTimetablesController(
                deleteDoctorTimetablesUseCase.Object,
                cache.Object,
                doctorTimetablesDateDbGateway.Object,
                doctorTimetablesTimeDbGateway.Object
                );

            var dto = new DoctorTimetablesDateEntity
            {
                DeleteDate = DateTime.Now,
                Id = "a",
                IdDoctor = "b",
                DoctorTimetablesTimes = new List<DoctorTimetablesTimeEntity>
                 {
                     new DoctorTimetablesTimeEntity
                     {
                         DeleteDate = DateTime.Now,
                         Id = "c",
                         Time = "10:00",
                         IdDoctorsTimetablesDate = "b"
                     }
                 }
            };

            await Assert.ThrowsAsync<Exception>(async () => await controller.DeleteAsync(dto));
        }
    }
}
