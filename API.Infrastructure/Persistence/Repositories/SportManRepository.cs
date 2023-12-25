using Domain.ScoreWeigths;
using Domain.SportMen;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Infrastructure.Persistence.Repositories
{
	public class SportManRepository : ISportManRepository
	{
		private readonly ApplicationDbContext _context;

		public SportManRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<ICollection<SportMan>> GetAttempts()
		{
			var query = from w in _context.ScoreWeigth
						join s in _context.SportMan on w.SportManId equals s.Id
						group w by new { w.SportManId, s.Name } into g
						select new SportMan()
						{
							Attempts = g.Count(),
							Name = g.Key.Name
						};

			return await query.ToListAsync();
		}
	}
}
