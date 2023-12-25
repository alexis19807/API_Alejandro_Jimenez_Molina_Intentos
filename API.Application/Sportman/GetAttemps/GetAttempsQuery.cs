using MediatR;

namespace Application.Sportman.GetAll
{
	public record GetAttempsQuery() : IRequest<ICollection<GetAttempsQueryResponse>>;
}
