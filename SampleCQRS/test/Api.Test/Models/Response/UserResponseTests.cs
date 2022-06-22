using Api.Models.Response;
using Domain.Entities;

namespace Api.Test.Models.Response
{
    public class UserResponseTests
    {
        [Fact]
        public async void CastToUserResponse_ValidInput_MustReturnUser()
        {
            //Arrange
            var request = new User
            {
                Document = "123",
                Name = "name"
            };

            //Act
            var user = (UserResponse)request;

            //Assert
            Assert.NotNull(user);
            Assert.Equal(user.Name, request.Name);
            Assert.Equal(user.Document, request.Document);
        }

        [Fact]
        public async void CastToUserResponse_InvalidInput_MustReturnNull()
        {

            //Arrange
            User request = null;

            //Act
            var user = (UserResponse)request;

            //Assert
            Assert.Null(user);
        }
    }
}
