using Domain.Primitives;
using Domain.Users;
using MediatR;

namespace Application.Users.Create
{
	public class SignInCommandHandler : IRequestHandler<SignInCommand, bool>
	{
		private readonly ILoginRepository _loginRepository;
		private readonly IUnitOfWork _unitOfWork;

		public SignInCommandHandler(ILoginRepository loginRepository,
			IUnitOfWork unitOfWork)
		{
			_loginRepository = loginRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<bool> Handle(SignInCommand command, CancellationToken cancellationToken)
		{
			var user = new User()
			{
				UserName = command.userName,
				Password = command.password
			};

			var result = await this._loginRepository.SingInAsync(user);

			await _unitOfWork.SaveChangesAsync(cancellationToken);

			return result;
		}
	}
}
