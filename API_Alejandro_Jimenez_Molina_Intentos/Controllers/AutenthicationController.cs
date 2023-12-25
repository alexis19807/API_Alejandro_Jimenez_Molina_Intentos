using Application.Users.Create;
using Application.Users.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_Alejandro_Jimenez_Molina.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AutenthicationController : ControllerBase
	{
		private string? SecretKey { get; set; }

		private readonly IConfiguration _configuration;
		private readonly IMediator _mediator;

		public AutenthicationController(IConfiguration configuration,
			IMediator mediator)
		{
			_configuration = configuration;
			SecretKey = _configuration.GetSection("Settings").GetSection("SecretKey").Value.ToString();
			_mediator = mediator;
		}

		[HttpGet]
		[Route("Login")]
		public async Task<IActionResult> Login([FromQuery] LoginQuery request)
		{
			var success = await _mediator.Send(request);

			if (!success)
			{
				return BadRequest();
			}

			var key = Encoding.ASCII.GetBytes(SecretKey);
			var claims = new ClaimsIdentity();

			claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.userName));

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Issuer = "https://localhost:7122/",
				Audience = "https://localhost:7122/",
				Subject = claims,
				Expires = DateTime.UtcNow.AddMinutes(5),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

			var tokenCreated = tokenHandler.WriteToken(tokenConfig);

			return Ok(new { token = tokenCreated });
		}

		[HttpPost]
		public async Task<IActionResult> SignIn([FromBody] SignInCommand command)
		{
			var success = await _mediator.Send(command);

			return Ok(success);
		}
	}
}
