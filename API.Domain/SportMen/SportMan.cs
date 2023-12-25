using Domain.Primitives;
using Domain.ScoreWeigths;

namespace Domain.SportMen
{
    public class SportMan : AggregateRoot
    {
        public Guid Id { get; set; }
        public string Country { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public ICollection<ScoreWeigth> ScoreWeigths { get; set; }
        public int Attempts { get; set; }

        public SportMan()
        {
        }

		public SportMan(Guid id, string? country, string? name)
		{
			Id = id;
			Country = country;
			Name = name;
		}
	}
}
