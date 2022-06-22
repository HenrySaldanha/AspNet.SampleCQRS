This repository aims to present a simple implementation of the CQRS pattern using MediatR.

## Settings

In my **Program** class I added the following code snippets:
   
The **AddMediatR** function is responsible for setting the MediatR dependency injection into the solution.
The parameter must be some object in the project where there are implementations of commands, queries and notifications.

    public static void ConfigureServices(this IServiceCollection services)
    {
            services.AddControllers();
            services.AddMediatR(typeof(CreateUserHandler).Assembly);
	    ...
    }
    

## Command class implementation
I created the **CreateUserCommand** class for the command implementation. The purpose of this command is to create a new user.
It is very important that we do not forget to implement the class **IRequest** and inform the return of our command, which in my case is **User**.

    public class CreateUserCommand : IRequest<User>
    {
        public CreateUserCommand(User user)
        {
            User = user;
        }

        public User User { get; set; }
    }


## Handler class implementation
The handler **CreateUserHandler** needs to implement the **IRequestHandler** interface and we need to set the input and output objects of the handler, in my case the input is the **CreateUserCommand** and the output is **User**.

    public class CreateUserHandler : IRequestHandler<CreateUserCommand, User>
    {
        public Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            request.User.Id = Guid.NewGuid();
            return Task.FromResult(request.User);
        }
    }


## Controller class implementation
To call the command we need to inject the dependency of the **IMediator** class and then use the **Send()** function passing a command as parameter.
The **[FromServices]** tag injects a dependency on the **IMediator**.
        
        [HttpPost]
        public async Task<ActionResult> CreateUserAsync(
            [FromServices] IMediator _mediator,
            [FromBody] CreateUserRequest userRequest)
        {
            UserResponse user = await _mediator.Send(new CreateUserCommand(userRequest));

            ...
        }


## This project was built with
* [.NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
* [MediatR](https://www.nuget.org/packages/MediatR/)
* [Swagger](https://swagger.io/)
* ~~coffee, pizza and late nights~~

## My contacts
* [LinkedIn](https://www.linkedin.com/in/henry-saldanha-3b930b98/)
