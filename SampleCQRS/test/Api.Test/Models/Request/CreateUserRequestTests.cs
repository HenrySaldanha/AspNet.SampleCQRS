using Api.Models.Request;
using Domain.Entities;

namespace Api.Test.Models.Request
{
    public class CreateUserRequestTests
    {
        [Fact]
        public async void CastToUser_ValidInput_MustReturnUser()
        {
            //Arrange
            var request = new CreateUserRequest
            {
                Document = "123",
                Name = "name"
            };

            //Act
            var user = (User)request;

            //Assert
            Assert.NotNull(user);
            Assert.Equal(user.Name, request.Name);
            Assert.Equal(user.Document, request.Document);
        }

        [Fact]
        public async void CastToUser_InvalidInput_MustReturnNull()
        {

            //Arrange
            CreateUserRequest request = null;

            //Act
            var user = (User)request;

            //Assert
            Assert.Null(user);
        }
    }
}
