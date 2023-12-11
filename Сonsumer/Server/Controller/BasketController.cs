using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Cache;
using Server.Model;

namespace Server.Controller
{
	[ApiController]
	[Route("api/[controller]")]
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

		#region Методы

		/// <summary>
		/// Получить все книги из корзины.
		/// </summary>
		/// <returns>Все книги из корзины.</returns>
		[HttpGet]
		public IActionResult GetBasketBooks()
		{
			logger.LogTrace($"Get all book from basket");
			return new JsonResult(this.cache.GetAll());
		}

		/// <summary>
		/// Добавить книгу в корзину.
		/// </summary>
		/// <param name="book">Выбранная книга.</param>
		/// <returns>True - если успешно добавлена или обновлёна книга, иначе False.</returns>
		[HttpPost]
		public IActionResult AddBasketBook(Book book)
		{
			if (book == null)
				return new JsonResult(false);
			return new JsonResult(this.cache.AddOrUpdate(book.Id, book));
		}

		/// <summary>
		/// Удалить книгу из корзины.
		/// </summary>
		/// <param name="bookId">Идентификатор книги.</param>
		/// <returns>True - если успешно удалась книга, иначе False.</returns>
		[HttpDelete]
		public IActionResult RemoveBasketBook([FromQuery] string bookId)
		{
			return new JsonResult(this.cache.Remove(bookId));
		}

		#endregion

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
