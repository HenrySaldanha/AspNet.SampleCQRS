using Api.Models.Request;
using Application.Commands;
using Application.Query;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Test.Controllers
{
    public class UserControllerTests
    {
        private readonly UserController _controller;
        private readonly Mock<IMediator> _mediator;

        public UserControllerTests()
        {
            _mediator = new Mock<IMediator>();
            _controller = new UserController();
        }

        [Fact]
        public async void CreateUserAsync_ValidRequest_MustReturnBadRequest()
        {
            //Arrange
            var request = new CreateUserRequest
            {
                Document = "123",
                Name = "name"
            };

            //Act
            var response = await _controller.CreateUserAsync(_mediator.Object, request);

            //Assert
            _mediator.Verify(c => c.Send(It.Is<CreateUserCommand>(e => e.User.Document == request.Document), It.IsAny<CancellationToken>()), Times.Once);
            Assert.IsType<BadRequestResult>(response);
        }

        [Fact]
        public async void CreateUserAsync_ValidRequest_MustReturnOk()
        {
            //Arrange
            var request = new CreateUserRequest
            {
                Document = "123",
                Name = "name"
            };

            var user = (User)request;

            _mediator.Setup(c => c.Send(It.Is<CreateUserCommand>(e => e.User.Document == request.Document), It.IsAny<CancellationToken>()))
                .ReturnsAsync(user);

            //Act
            var response = await _controller.CreateUserAsync(_mediator.Object, request);

            //Assert
            _mediator.Verify(c => c.Send(It.Is<CreateUserCommand>(e => e.User.Document == request.Document), It.IsAny<CancellationToken>()), Times.Once);
            Assert.IsType<CreatedResult>(response);
        }

        [Fact]
        public async void GetByIdAsync_InvalidRequest_MustReturnBadRequest()
        {
            //Arrange
            var request = Guid.Empty;

            //Act
            var response = await _controller.GetByIdAsync(_mediator.Object, request);

            //Assert
            _mediator.Verify(c => c.Send(It.Is<GetUserQuery>(e => e.Id == request), It.IsAny<CancellationToken>()), Times.Never);
            Assert.IsType<BadRequestResult>(response);
        }

        [Fact]
        public async void GetByIdAsync_ValidRequest_MustReturnOk()
        {
            //Arrange
            var request = Guid.NewGuid();

            var userResponse = new User
            {
                Document = "123",
                Name = "name"
            };

            _mediator.Setup(c => c.Send(It.Is<GetUserQuery>(e => e.Id == request), It.IsAny<CancellationToken>()))
                .ReturnsAsync(userResponse);

            //Act
            var response = await _controller.GetByIdAsync(_mediator.Object, request);

            //Assert
            _mediator.Verify(c => c.Send(It.Is<GetUserQuery>(e => e.Id == request), It.IsAny<CancellationToken>()), Times.Once);
            Assert.IsType<OkObjectResult>(response);
        }
    }
}
