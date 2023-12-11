using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Cache;
using Server.Model;

namespace Server.Controller
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class BasketController : ControllerBase
	{
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

		[HttpGet]
		public IActionResult GetBasketBooks()
		{
			logger.LogTrace($"Get all book from basket");
			return new JsonResult(this.cache.GetAll());
		}

		[HttpPost]
		public IActionResult AddBasketBook(Book book)
		{
			if (book == null)
				return new JsonResult(false);
			return new JsonResult(this.cache.AddOrUpdate(book.Id, book));
		}

		[HttpDelete]
		public IActionResult RemoveBasketBook([FromQuery] string bookId)
		{
			return new JsonResult(this.cache.Remove(bookId));
		}

		#region Конструктор

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="logger">Логгер.</param>
		public BasketController(ILogger<BasketController> logger) 
		{
			this.logger = logger;
			this.cache = new BookCache();
		}

		#endregion
	}
}
