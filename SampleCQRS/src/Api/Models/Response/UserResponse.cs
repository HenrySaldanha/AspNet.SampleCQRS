using Domain.Entities;

namespace Api.Models.Response
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }

        public static implicit operator UserResponse(User user)
        {
            if (user is null)
                return null;

            return new UserResponse
            {
                Document = user.Document,
                Name = user.Name,
                Id = user.Id
            };
        }
    }
}
