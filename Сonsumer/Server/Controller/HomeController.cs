using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Service;

namespace Server.Controller
{
	[ApiVersion(1.0)]
	[ApiController]
	[Route("api/v{version:apiVersion}/[action]")]
	public class HomeController : ControllerBase
	{
		#region Поля и свойства

		/// <summary>
		/// Логгер.
		/// </summary>
		private readonly ILogger logger;

		#endregion

		#region Методы

		/// <summary>
		/// Состояние сервера.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Health()
		{
			logger.LogTrace($"Check health.");
			return Ok();
		}

		/// <summary>
		/// Получить версию билда.
		/// </summary>
		/// <returns>Версия билда.</returns>
		public IActionResult Version()
		{
			logger.LogTrace($"Get version.");
			return new JsonResult(ServerInfo.GetInstance.GetVersion());
		}

		/// <summary>
		/// Метрики сервера.
		/// </summary>
		/// <returns>Нагрузка CPU и RAM.</returns>
		public IActionResult Metrics()
		{
			logger.LogTrace($"Get metrics.");
			return new JsonResult(ServerInfo.GetInstance.GetCurrentCpuUsage() + ServerInfo.GetInstance.GetAvailableRam());
		}

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
