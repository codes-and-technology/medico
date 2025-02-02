﻿using Controllers.Update;
using Entitys;
using Moq;
using Entitys;
using Gateways.Cache;
using Gateways.Database;
using UseCases.Update;

namespace RegionalContactsWorkerUpdate.Unit.Tests
{
    public class UpdateContactControllerUnitTest
    {
        [Theory]
        [InlineData("teste", "1243", 0, "teste")]
        [InlineData("teste@gmail.com", "145123", 13, "")]
        [InlineData("teste@gmail.com", "", 13, "teste teste teste teste teste  teste  teste testeteste teste teste teste teste  teste  teste testeteste teste teste teste teste  teste  teste testeteste teste teste teste teste  teste  teste testeteste teste teste teste teste  teste  teste testeteste teste teste teste teste  teste  teste testeteste teste teste teste teste  teste  teste teste")]
        [InlineData("teste teste teste teste teste  teste  teste testeteste teste teste teste teste  teste  teste testeteste teste teste teste teste  teste  teste testeteste teste teste teste teste  teste  teste testeteste teste teste teste teste  teste  teste testeteste teste teste teste teste  teste  teste testeteste teste teste teste teste  teste  teste teste", "988027555", 13, "")]
        public async Task When_UpdateAsync_ShouldBe_Error(string email, string phone, short region, string name)
        {
            var cache = new Mock<ICacheGateway<ContactEntity>>();
            cache.Setup(s => s.SaveCacheAsync(It.IsAny<string>(), It.IsAny<List<ContactEntity>>())).Verifiable();
            cache.Setup(s => s.GetCacheAsync(It.IsAny<string>())).ReturnsAsync(new List<ContactEntity>());
            cache.Setup(s => s.ClearCacheAsync(It.IsAny<string>())).Verifiable();

            var entity = new ContactEntity
            {
                CreateDate = DateTime.Now,
                Email = email,
                Id = Guid.NewGuid(),
                Name = name,
                PhoneNumber = phone,
                PhoneRegion = new PhoneRegionEntity
                {
                    CreateDate = DateTime.Now,
                    Id = Guid.NewGuid(),
                    RegionNumber = region
                }
            };

            var contactDBGatewayMock = new Mock<IContactDBGateway>();
            contactDBGatewayMock.Setup(s => s.AddAsync(entity)).Verifiable();

            var phoneRegionDBGatewayMock = new Mock<IPhoneRegionDBGateway>();
            phoneRegionDBGatewayMock.Setup(s => s.AddAsync(entity.PhoneRegion)).Verifiable();
            phoneRegionDBGatewayMock.Setup(s => s.GetByRegionNumberAsync(It.IsAny<short>())).ReturnsAsync(new PhoneRegionEntity());

            var useCase = new UpdateContactUseCase();
            UpdateContactController controller = new(contactDBGatewayMock.Object, phoneRegionDBGatewayMock.Object, useCase, cache.Object);

            var result = await controller.UpdateAsync(entity);
            Assert.True(result.Errors.Count > 0);
        }

        [Theory]
        [InlineData("teste@gmail.com", "988027777", 11, "Usuário Teste")]
        public async Task When_UpdateAsync_ShouldBe_Ok(string email, string phone, short region, string name)
        {
            var cache = new Mock<ICacheGateway<ContactEntity>>();
            cache.Setup(s => s.SaveCacheAsync(It.IsAny<string>(), It.IsAny<List<ContactEntity>>())).Verifiable();
            cache.Setup(s => s.GetCacheAsync(It.IsAny<string>())).ReturnsAsync(new List<ContactEntity>());
            cache.Setup(s => s.ClearCacheAsync(It.IsAny<string>())).Verifiable();

            var entity = new ContactEntity
            {
                CreateDate = DateTime.Now,
                Email = email,
                Id = Guid.NewGuid(),
                Name = name,
                PhoneNumber = phone,
                PhoneRegion = new PhoneRegionEntity
                {
                    CreateDate = DateTime.Now,
                    Id = Guid.NewGuid(),
                    RegionNumber = region
                }
            };

            var contactDBGatewayMock = new Mock<IContactDBGateway>();
            contactDBGatewayMock.Setup(s => s.AddAsync(entity)).Verifiable();

            var phoneRegionDBGatewayMock = new Mock<IPhoneRegionDBGateway>();
            phoneRegionDBGatewayMock.Setup(s => s.AddAsync(entity.PhoneRegion)).Verifiable();
            phoneRegionDBGatewayMock.Setup(s => s.GetByRegionNumberAsync(It.IsAny<short>())).ReturnsAsync(new PhoneRegionEntity());

            var useCase = new UpdateContactUseCase();
            UpdateContactController controller = new(contactDBGatewayMock.Object, phoneRegionDBGatewayMock.Object, useCase, cache.Object);

            var result = await controller.UpdateAsync(entity);
            Assert.True(result.Success);
        }
    }
}
