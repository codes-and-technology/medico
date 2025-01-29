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
        public async Task When_CreateContact_ShouldBe_Ok(string name, string document, string email)
        {
            var userDbGateway = new Mock<IUserDBGateway>();
            var authDbGateway = new Mock<IAuthDBGateway>();

            userDbGateway.Setup(s => s.FirstOrDefaultAsync(It.IsAny<Expression<Func<UserEntity, bool>>>()))
                .ReturnsAsync(null as UserEntity);
            var createContactController = new CreateUserController(userDbGateway.Object, authDbGateway.Object);

            UserDto dto = new()
            {
                Name = name,
                Email = email,
                DocumentNumber = document
            };

            var result = await createContactController.CreateUserAsync(dto);

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("usuario teste", "988027555", "teste@teste.com")]
        public async Task When_CreateContact_ShouldBe_Error_WithContactExists(string name, string document, string email)
        {
            var userDbGateway = new Mock<IUserDBGateway>();
            var authDbGateway = new Mock<IAuthDBGateway>();

            userDbGateway.Setup(s => s.FirstOrDefaultAsync(It.IsAny<Expression<Func<UserEntity, bool>>>()))
                .ReturnsAsync(new UserEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = email
                });
            var createContactController = new CreateUserController(userDbGateway.Object, authDbGateway.Object);

            UserDto dto = new()
            {
                Name = name,
                Email = email,
                DocumentNumber = document
            };

            var result = await createContactController.CreateUserAsync(dto);

            Assert.False(result.Success);
        }

        
        [Theory]
        [InlineData("usuario teste", "40993229808", "")]
        [InlineData("usuario teste", "", "")]
        [InlineData("", "57829013457082349", "teste@teste.com")]
        public async Task When_CreateContact_ShouldBe_Error_WithInvalidDto(string name, string document, string email)
        {
            var userDbGateway = new Mock<IUserDBGateway>();
            var authDbGateway = new Mock<IAuthDBGateway>();

            userDbGateway.Setup(s => s.FirstOrDefaultAsync(It.IsAny<Expression<Func<UserEntity, bool>>>()))
                .ReturnsAsync(null as UserEntity);
            var createContactController = new CreateUserController(userDbGateway.Object, authDbGateway.Object);

            UserDto dto = new()
            {
                Name = name,
                Email = email,
                DocumentNumber= document,
            };

            var result = await createContactController.CreateUserAsync(dto);

            Assert.False(result.Success);
        }
    }
}