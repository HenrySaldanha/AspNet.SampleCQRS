using Application.Query;
using Domain.Entities;
using MediatR;

namespace Application.QueryHandler
{
    public class GetUserHandler : IRequestHandler<GetUserQuery, User>
    {
        public Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Document = "12312312312",
                Id = Guid.NewGuid(),
                Name = "Full Name"
            };

            return Task.FromResult(user);
        }
    }
}
