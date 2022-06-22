using Domain.Entities;

namespace Api.Models.Request
{
    public class CreateUserRequest
    {
        public string Name { get; set; }
        public string Document { get; set; }

        public static implicit operator User(CreateUserRequest request)
        {
            if(request == null) 
                return null;

            return new User
            {
               Document = request.Document,
               Name = request.Name
            };
        }
    }
}
