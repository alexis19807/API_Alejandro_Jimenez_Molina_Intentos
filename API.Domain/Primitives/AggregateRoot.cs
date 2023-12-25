namespace Domain.Primitives
{
	//Abstract class that allows inheriting domain events
	public abstract class AggregateRoot
	{
		private readonly List<DomainEvent> _domainEvents = new();

		//List of domain events of the aggregate and expose instead straight from property
		public ICollection<DomainEvent> GetDomainEvents() => _domainEvents;

		//Execute the domain event
		protected void Raise(DomainEvent domainEvent)
		{
			_domainEvents.Add(domainEvent);
		}
	}
}
