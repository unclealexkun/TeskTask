using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Server.Cache;
using Server.Model;

namespace Server.Controller
{
	[ApiController]
	[Route("api/[controller]")]
	public class BookController : ControllerBase
	{
		#region Константы

		private const string dataPathPrefix = @"\Data\books.json";

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

		#region Методы

		/// <summary>
		/// Получить список всех книг.
		/// </summary>
		/// <returns>Список всех книг</returns>
		[HttpGet]
		public IActionResult GetAllBooks()
		{
			logger.LogTrace($"Get all book");
			return new JsonResult(this.cache.GetAll());
		}

		/// <summary>
		/// Получить список всех книг по наименованию.
		/// </summary>
		/// <param name="name">Название книги.</param>
		/// <returns>Список всех книг по наименованию.</returns>
		[HttpGet]
		public IActionResult GetBooksByName([FromQuery] string name)
		{
			logger.LogTrace($"Get book by name: {name}");
			return new JsonResult(this.cache.GetAll().FirstOrDefault(c => c.Title.Contains(name)));
		}

		/// <summary>
		/// Получить список всех книг по автору.
		/// </summary>
		/// <param name="author">Автор книги.</param>
		/// <returns>Список всех книг по автору.</returns>
		[HttpGet]
		public IActionResult GetBooksByAuthor([FromQuery] string author)
		{
			logger.LogTrace($"Get book by author: {author}");
			return new JsonResult(this.cache.GetAll().Where(c => c.Authors.Any(a => a.Name.Contains(author))));
		}

		/// <summary>
		/// Получить список всех книг по категориям.
		/// </summary>
		/// <param name="category">Категория книги.</param>
		/// <returns>Список всех книг по категориям.</returns>
		[HttpGet]
		public IActionResult GetBooksByCategory([FromQuery] string category)
		{
			logger.LogTrace($"Get books by category: {category}");
			return new JsonResult(this.cache.GetAll().Where(c => c.Сategory.Contains(category)));
		}

		/// <summary>
		/// Получить все книжные категории.
		/// </summary>
		/// <returns>Книжные категории.</returns>
		[HttpGet]
		public IActionResult GetBookCategories()
		{
			logger.LogTrace($"Get book categories");
			return new JsonResult(this.cache.GetAll().Select(c => c.Сategory).Distinct().Order());
		}

		#endregion

		#region Конструктор

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="logger">Логгер.</param>
		/// <param name="cache">Кеш.</param>
		public BookController(ILogger<BookController> logger, IBookCache cache)
		{
			this.logger = logger;
			this.cache = cache;

			if (System.IO.File.Exists(Directory.GetCurrentDirectory() + dataPathPrefix))
			{
				var serializer = new JsonSerializer();
				using (var reader = new StreamReader(Directory.GetCurrentDirectory() + dataPathPrefix))
				using (var jsonReader = new JsonTextReader(reader))
				{
					var books = serializer.Deserialize<IEnumerable<Book>>(jsonReader) ?? Enumerable.Empty<Book>();
					foreach (var book in books)
						this.cache.AddOrUpdate(book.Id, book);
				}
			}
		}

		#endregion
	}
}
