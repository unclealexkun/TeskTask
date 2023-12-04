using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Server.Controller
{
	public class BookController : ControllerBase
	{
		#region Поля и свойства

		/// <summary>
		/// Логгер.
		/// </summary>
		private readonly ILogger logger;

		#endregion

		[Route("book/get")]
		public string Get()
		{
			logger.LogTrace("Работаем");
			return "Привет, Сернатурал!";
		}

		#region Конструктор

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="logger">Логгер.</param>
		public BookController(ILogger<BookController> logger)
		{
			this.logger = logger;
		}

		#endregion
	}
}
