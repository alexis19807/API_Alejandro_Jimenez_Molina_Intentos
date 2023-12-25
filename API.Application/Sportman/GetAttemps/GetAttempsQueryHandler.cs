using Domain.ScoreWeigths;
using Domain.SportMen;
using MediatR;

namespace Application.Sportman.GetAll
{
	public class GetAttempsQueryHandler : IRequestHandler<GetAttempsQuery, ICollection<GetAttempsQueryResponse>>
	{
		private readonly ISportManRepository _sportManRepository;

		public GetAttempsQueryHandler(ISportManRepository sportManRepository)
		{
			_sportManRepository = sportManRepository;
		}

		//Using MediatR get each sportman with the best score of each category
		public async Task<ICollection<GetAttempsQueryResponse>> Handle(GetAttempsQuery query, CancellationToken cancellationToken)
		{
			var sportmen = new List<GetAttempsQueryResponse>();

			var result = await this._sportManRepository.GetAttempts();

			foreach ( var item in result)
			{
				sportmen.Add(new GetAttempsQueryResponse()
				{
					Name = item.Name,
					Attempts = item.Attempts
				});
			}

			return sportmen;
		}
	}
}
