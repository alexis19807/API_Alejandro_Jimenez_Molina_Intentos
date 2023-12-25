using Domain.Users;
using MediatR;

namespace Application.Users.Get
{
	public class LoginQueryHandler : IRequestHandler<LoginQuery, bool>
	{
		private readonly ILoginRepository _loginRepository;

		public LoginQueryHandler(ILoginRepository loginRepository)
		{
			_loginRepository = loginRepository;
		}

		public async Task<bool> Handle(LoginQuery query, CancellationToken cancellationToken)
		{
			return await _loginRepository.LoginAsync(new User()
			{
				UserName = query.userName,
				Password = query.password
			});
		}
	}
}
