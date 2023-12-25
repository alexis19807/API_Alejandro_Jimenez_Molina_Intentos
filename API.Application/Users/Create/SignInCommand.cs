using MediatR;

namespace Application.Users.Create
{
	public record SignInCommand(string userName, string password) : IRequest<bool>;
}
