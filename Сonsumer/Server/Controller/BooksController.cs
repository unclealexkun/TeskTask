using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Cache;
using Server.Service;

namespace Server.Controller
{
	[ApiController]
	[Route("api/[controller]")]
	public class BooksController : ControllerBase
	{
		#region Поля и свойства

		/// <summary>
		/// Логгер.
		/// </summary>
		private readonly ILogger logger;

		/// <summary>
		/// Хранилище книг.
		/// </summary>
		private readonly IBookStore store;

		#endregion

		#region Методы

		/// <summary>
		/// Получить список всех книг.
		/// </summary>
		/// <returns>Список всех книг</returns>
		[HttpGet]
		public IActionResult GetAllBooks()
		{
			logger.LogTrace($"Get all book");
			return new JsonResult(this.store.GetAllBooks());
		}

		/// <summary>
		/// Получить список всех книг по наименованию.
		/// </summary>
		/// <param name="title">Название книги.</param>
		/// <returns>Список всех книг по наименованию.</returns>
		[HttpGet("titlies/{title}")]
		public IActionResult GetBooksByTitle(string title)
		{
			logger.LogTrace($"Get book by name: {title}");
			return new JsonResult(this.store.GetBooksByTitle(title));
		}

		/// <summary>
		/// Получить список всех книг по автору.
		/// </summary>
		/// <param name="author">Автор книги.</param>
		/// <returns>Список всех книг по автору.</returns>
		[HttpGet("authors/{author}")]
		public IActionResult GetBooksByAuthor(string author)
		{
			logger.LogTrace($"Get book by author: {author}");
			return new JsonResult(this.store.GetBooksByAuthor(author));
		}

		/// <summary>
		/// Получить список всех книг по категориям.
		/// </summary>
		/// <param name="category">Категория книги.</param>
		/// <returns>Список всех книг по категориям.</returns>
		[HttpGet("categories/{category}")]
		public IActionResult GetBooksByCategory(string category)
		{
			logger.LogTrace($"Get books by category: {category}");
			return new JsonResult(this.store.GetBooksByCategory(category));
		}

		/// <summary>
		/// Получить все книжные категории.
		/// </summary>
		/// <returns>Книжные категории.</returns>
		[HttpGet("categories")]
		public IActionResult GetBookCategories()
		{
			logger.LogTrace($"Get book categories");
			return new JsonResult(this.store.GetBookCategories());
		}

		#endregion

		#region Конструктор

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="logger">Логгер.</param>
		/// <param name="cache">Кеш.</param>
		public BooksController(ILogger<BooksController> logger, IBookCache cache)
		{
			this.logger = logger;
			this.store = new BookStore(cache);
		}

		#endregion
	}
}
