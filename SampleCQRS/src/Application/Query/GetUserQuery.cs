using Domain.Entities;
using MediatR;

namespace Application.Query
{
    public class GetUserQuery : IRequest<User>
    {
        public GetUserQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
