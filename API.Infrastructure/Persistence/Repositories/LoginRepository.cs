using Domain.Users;
using Serilog;

namespace Infrastructure.Persistence.Repositories
{
	public class LoginRepository : ILoginRepository
	{
		private readonly ApplicationDbContext _context;

		public LoginRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<bool> LoginAsync(User user)
		{
			await Task.CompletedTask;
			return true;
		}

		public async Task<bool> SingInAsync(User user)
		{
			try
			{
				await _context.User.AddAsync(user);
			}
			catch (Exception e)
			{
				Log.Error($"Error creating user in the database - {e.Message}");
				return false;
			}

			return true;
		}
	}
}
