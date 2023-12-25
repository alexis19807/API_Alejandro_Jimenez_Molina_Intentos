namespace Domain.SportMen
{
	public interface ISportManRepository
	{
		Task<ICollection<SportMan>> GetAttempts();
	}
}
