using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Cache;

namespace Server.Controller
{
	public class BookController : ControllerBase
	{
		#region Константы

		private const string dataPathPrefix = @"~/Data/books.json";

		#endregion

		#region Поля и свойства

		/// <summary>
		/// Логгер.
		/// </summary>
		private readonly ILogger logger;

		/// <summary>
		/// Кеш книг.
		/// </summary>
		private readonly IBookCache cache;

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

			//if (System.IO.File.Exists())
			//{
			//	System.IO.File.ReadAllText(HostingEnvironment.MapPath(dataPathPrefix));
			//}
		}

		#endregion
	}
}
