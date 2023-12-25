using Application.Sportman.GetAll;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Alejandro_Jimenez_Molina.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[Authorize]
	public class SportManController : ControllerBase
	{
		private readonly IMediator _mediator;

		public SportManController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> SportManAttempts()
		{
			var result = await _mediator.Send(new GetAttempsQuery());

			return Ok(result);
		}
	}
}