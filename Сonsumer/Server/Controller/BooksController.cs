using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Cache;
using Server.Model;
using Server.Service;

namespace Server.Controller
{
	[ApiVersion(1.0)]
	[ApiController]
	[Route("api/v{version:apiVersion}/[controller]")]
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
		/// <param name="pagedListParameters">Параметры для пагинации.</param>
		/// <returns>Список всех книг</returns>
		[HttpGet]
		public IActionResult GetAllBooks([FromQuery] PagedListParameters pagedListParameters)
		{
			logger.LogTrace($"Get all book");
			return new JsonResult(this.store.GetAllBooks(pagedListParameters));
		}

		/// <summary>
		/// Получить список всех книг по наименованию.
		/// </summary>
		/// <param name="title">Название книги.</param>
		/// <param name="pagedListParameters">Параметры для пагинации.</param>
		/// <returns>Список всех книг по наименованию.</returns>
		[HttpGet("titlies/{title}")]
		public IActionResult GetBooksByTitle(string title, [FromQuery] PagedListParameters pagedListParameters)
		{
			logger.LogTrace($"Get book by name: {title}");
			return new JsonResult(this.store.GetBooksByTitle(title, pagedListParameters));
		}

		/// <summary>
		/// Получить список всех книг по автору.
		/// </summary>
		/// <param name="author">Автор книги.</param>
		/// <param name="pagedListParameters">Параметры для пагинации.</param>
		/// <returns>Список всех книг по автору.</returns>
		[HttpGet("authors/{author}")]
		public IActionResult GetBooksByAuthor(string author, [FromQuery] PagedListParameters pagedListParameters)
		{
			logger.LogTrace($"Get book by author: {author}");
			return new JsonResult(this.store.GetBooksByAuthor(author, pagedListParameters));
		}

		/// <summary>
		/// Получить список всех книг по категориям.
		/// </summary>
		/// <param name="category">Категория книги.</param>
		/// <param name="pagedListParameters">Параметры для пагинации.</param>
		/// <returns>Список всех книг по категориям.</returns>
		[HttpGet("categories/{category}")]
		public IActionResult GetBooksByCategory(string category, [FromQuery] PagedListParameters pagedListParameters)
		{
			logger.LogTrace($"Get books by category: {category}");
			return new JsonResult(this.store.GetBooksByCategory(category, pagedListParameters));
		}

		/// <summary>
		/// Получить все книжные категории.
		/// </summary>
		/// <param name="pagedListParameters">Параметры для пагинации.</param>
		/// <returns>Книжные категории.</returns>
		[HttpGet("categories")]
		public IActionResult GetBookCategories([FromQuery] PagedListParameters pagedListParameters)
		{
			logger.LogTrace($"Get book categories");
			return new JsonResult(this.store.GetBookCategories(pagedListParameters));
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
