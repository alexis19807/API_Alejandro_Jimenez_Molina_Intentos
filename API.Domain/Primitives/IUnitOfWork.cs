namespace Domain.Primitives
{
	//Implementation UnitOfWork pattern to group all the database operations along with Repository pattern
	public interface IUnitOfWork
	{
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}
