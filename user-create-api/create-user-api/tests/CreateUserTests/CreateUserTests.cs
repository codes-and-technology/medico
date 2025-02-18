using System.Linq.Expressions;
using CreateController;
using CreateEntitys;
using CreateInterface;
using Moq;
using Presenters;

namespace UserApiCreateTests
{
    public class CreateUserTests
    {
        [Theory]
        [InlineData("usuario teste", "40993229808", "teste@teste.com")]
        public async Task When_CreateUser_ShouldBe_Ok(string name, string document, string email)
        {
            var userDbGateway = new Mock<IUserDBGateway>();
            var authDbGateway = new Mock<IAuthDBGateway>();
            var cache = new Mock<ICacheGateway<UserEntity> >();

            userDbGateway.Setup(s => s.FirstOrDefaultAsync(It.IsAny<Expression<Func<UserEntity, bool>>>()))
                .ReturnsAsync(null as UserEntity);
            var createUserController = new CreateUserController(userDbGateway.Object, authDbGateway.Object, cache.Object);

            UserDto dto = new()
            {
                Name = name,
                Email = email,
                DocumentNumber = document,
                Password = "Teste@1235$%#@"
            };

            var result = await createUserController.CreateUserAsync(dto, "", 1, "geral",1);

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("usuario teste", "988027555", "teste@teste.com")]
        public async Task When_CreateUser_ShouldBe_Error_WithUserExists(string name, string document, string email)
        {
            var userDbGateway = new Mock<IUserDBGateway>();
            var authDbGateway = new Mock<IAuthDBGateway>();
            var cache = new Mock<ICacheGateway<UserEntity> >();

            userDbGateway.Setup(s => s.FirstOrDefaultAsync(It.IsAny<Expression<Func<UserEntity, bool>>>()))
                .ReturnsAsync(new UserEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = email
                });
            var createUserController = new CreateUserController(userDbGateway.Object, authDbGateway.Object, cache.Object);

            UserDto dto = new()
            {
                Name = name,
                Email = email,
                DocumentNumber = document
            };

            var result = await createUserController.CreateUserAsync(dto, "1243-SP", 1, "geral", 1);

            Assert.False(result.Success);
        }

        
        [Theory]
        [InlineData("usuario teste", "40993229808", "")]
        [InlineData("usuario teste", "", "")]
        [InlineData("", "57829013457082349", "teste@teste.com")]
        public async Task When_CreateUser_ShouldBe_Error_WithInvalidDto(string name, string document, string email)
        {
            var userDbGateway = new Mock<IUserDBGateway>();
            var authDbGateway = new Mock<IAuthDBGateway>();
            var cache = new Mock<ICacheGateway<UserEntity> >();

            userDbGateway.Setup(s => s.FirstOrDefaultAsync(It.IsAny<Expression<Func<UserEntity, bool>>>()))
                .ReturnsAsync(null as UserEntity);
            var createUserController = new CreateUserController(userDbGateway.Object, authDbGateway.Object, cache.Object);

            UserDto dto = new()
            {
                Name = name,
                Email = email,
                DocumentNumber= document,
            };

            var result = await createUserController.CreateUserAsync(dto, "", 1, "geral", 1);

            Assert.False(result.Success);
        }
    }
}