using Domain.Entities;
using MediatR;

namespace Application.Commands
{
    public class CreateUserCommand : IRequest<User>
    {
        public CreateUserCommand(User user)
        {
            User = user;
        }

        public User User { get; set; }
    }
}
