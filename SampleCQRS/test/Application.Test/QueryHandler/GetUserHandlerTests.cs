using Application.Query;
using Application.QueryHandler;

namespace Application.Test.QueryHandler
{
    public class GetUserHandlerTests
    {
        private readonly GetUserHandler _handler;

        public GetUserHandlerTests()
        {
            _handler = new GetUserHandler();
        }

        [Fact]
        public async Task Handle_ValidQuery_MustReturnUser()
        {
            //Arrange
            var command = new GetUserQuery(Guid.NewGuid());

            //Act
            var result = await _handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(command.Id, result.Id);
        }
    }
}
