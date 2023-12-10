using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Server.Cache;
using Server.Model;

namespace Server.Controller
{
	[ApiController]
	[Route("api/[controller]/[action]")]
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

		[HttpGet]
		public IActionResult GetAllBooks()
		{
			logger.LogTrace($"Get all book");
			return new JsonResult(this.cache.GetAll());
		}

		[HttpGet]
		public IActionResult GetBooksByName([FromQuery]string name)
		{
			logger.LogTrace($"Get book by name: {name}");
			return new JsonResult(this.cache.GetAll().FirstOrDefault(c => c.Title.Contains(name)));
		}

		[HttpGet]
		public IActionResult GetBooksByAuthor([FromQuery]string author)
		{
			logger.LogTrace($"Get book by author: {author}");
			return new JsonResult(this.cache.GetAll().Where(c => c.Authors.Any(a => a.Name.Contains(author))));
		}

		[HttpGet]
		public IActionResult GetBooksByCategory([FromQuery]string category)
		{
			logger.LogTrace($"Get books by category: {category}");
			return new JsonResult(this.cache.GetAll().Where(c => c.Сategory.Contains(category)));
		}

		[HttpGet]
		public IActionResult GetBookCategories()
		{
			logger.LogTrace($"Get book categories");
			return new JsonResult(this.cache.GetAll().Select(c => c.Сategory));
		}

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
