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
		/// Корзина с книгами.
		/// </summary>
		private readonly IBookCache basket;

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
			return new JsonResult(this.basket.GetAll());
		}

		/// <summary>
		/// Добавить книгу в корзину.
		/// </summary>
		/// <param name="book">Выбранная книга.</param>
		/// <returns>True - если успешно добавлена или обновлёна книга, иначе False.</returns>
		[HttpPost]
		public IActionResult AddBasketBook([FromBody]Book book)
		{
			logger.LogTrace($"Put book in basket");
			if (book == null)
				return new JsonResult(false);
			return new JsonResult(this.basket.AddOrUpdate(book.Id, book));
		}

		/// <summary>
		/// Удалить книгу из корзины.
		/// </summary>
		/// <param name="bookId">Идентификатор книги.</param>
		/// <returns>True - если успешно удалась книга, иначе False.</returns>
		[HttpDelete("{bookId}")]
		public IActionResult RemoveBasketBook(string bookId)
		{
			logger.LogTrace($"Remove book in basket");
			return new JsonResult(this.basket.Remove(bookId));
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
			this.basket = new BookCache();
		}

		#endregion
	}
}
