using Application.CommandHandlers;
using Application.Commands;
using Domain.Entities;

namespace Application.Test.CommandHandlers
{
    public class CreateUserHandlerTests
    {
        private readonly CreateUserHandler _handler;

        public CreateUserHandlerTests()
        {
            _handler = new CreateUserHandler();
        }

        [Fact]
        public async Task Handle_ValidCommand_MustReturnUser()
        {
            //Arrange
            var user = new User
            {
                Name = "Test",
                Document = "12312",
                Id = Guid.Empty
            };

            var command = new CreateUserCommand(user);

            //Act
            var result = await _handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(command.User, result);
            Assert.NotEqual(Guid.Empty, result.Id);

        }
    }
}