using Domain.ScoreWeigths;
using Domain.SportMen;
using Microsoft.EntityFrameworkCore;

namespace Application.Data
{
	public interface IApplicationDbContext
	{
		public DbSet<SportMan> SportMan { get; set; }
		public DbSet<ScoreWeigth> ScoreWeigth { get; set; }
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}
