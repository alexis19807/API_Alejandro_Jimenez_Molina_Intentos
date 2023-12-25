using Application.Data;
using Domain.Primitives;
using Domain.ScoreWeigths;
using Domain.SportMen;
using Domain.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
	public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
	{
		private readonly IPublisher _publisher;

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IPublisher publisher)
		: base(options)
		{
			_publisher = publisher;
		}

		public DbSet<SportMan> SportMan { get; set; }
		public DbSet<ScoreWeigth> ScoreWeigth { get; set; }
		public DbSet<User> User { get; set; }

		//We are override this to have custom configuration and we dont want to have the same map from the domain objects
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
		}

		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
		{
			var domainEvents = ChangeTracker.Entries<AggregateRoot>()
				.Select(e => e.Entity)
				.Where(e => e.GetDomainEvents().Any())
				.SelectMany(e => e.GetDomainEvents());

			var result = await base.SaveChangesAsync(cancellationToken);

			foreach (var domainEvent in domainEvents)
			{
				await _publisher.Publish(domainEvent, cancellationToken);
			}

			return result;
		}
	}
}
