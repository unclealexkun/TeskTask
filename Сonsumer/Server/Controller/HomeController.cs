using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Server.Controller
{
	[ApiController]
	[Route("api")]
	public class HomeController : ControllerBase
	{
		#region Поля и свойства

		/// <summary>
		/// Логгер.
		/// </summary>
		private readonly ILogger logger;

		#endregion

		#region Методы



		#endregion

		#region Конструктор

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="logger">Логгер.</param>
		public HomeController(ILogger<HomeController> logger)
		{
			this.logger = logger;
		}

		#endregion
	}
}
