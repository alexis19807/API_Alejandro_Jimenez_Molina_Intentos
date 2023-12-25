namespace Domain.Users
{
	public interface ILoginRepository
	{
		Task<bool> LoginAsync(User user);
		Task<bool> SingInAsync(User user);
	}
}
