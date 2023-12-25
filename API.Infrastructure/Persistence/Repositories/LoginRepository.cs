using Domain.Users;
using Microsoft.EntityFrameworkCore;
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
			User userExists;

			try
			{
				userExists = await _context.User.FirstOrDefaultAsync(u => u.UserName == user.UserName && u.Password == user.Password);
			}
			catch (Exception e)
			{
				Log.Error($"Error searching user in the database - {e.Message}");
				return false;
			}

			return userExists != null;
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
