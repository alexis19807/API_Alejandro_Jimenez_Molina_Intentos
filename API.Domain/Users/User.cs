namespace Domain.Users
{
	public class User
	{
		public Guid Id { get; set; } = new Guid();
        public string UserName { get; set; }
        public string Password { get; set; }

        public User()
        {
            
        }

		public User(string userName, string password)
		{
			UserName = userName;
			Password = password;
		}
	}
}
