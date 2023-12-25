using MediatR;

namespace Application.Users.Get
{
	public record LoginQuery(string userName, string password) : IRequest<bool>;
}
