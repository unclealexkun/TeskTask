using Newtonsoft.Json;
using NLog;
using Server.Cache;
using Server.Model;

namespace Server.Service
{
	public class BookStore : IBookStore
	{
		#region Константы

		/// <summary>
		/// Префикс пути с данными.
		/// </summary>
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

		public long Count<T>(IEnumerable<T> collection)
		{
			return collection.Count();
		}

		#endregion

		#region IBookStore

		public IEnumerable<string> GetBookCategories(PagedListParameters pagedListParameters)
		{
			return this.cache.GetAll()
				.Select(book => book.Сategory)
				.Distinct()
				.Order()
				.Skip((pagedListParameters.PageNumber - 1) * pagedListParameters.PageSize)
				.Take(pagedListParameters.PageSize)
				.ToList(); ;
		}

		public IEnumerable<Book> GetAllBooks(PagedListParameters pagedListParameters)
		{
			return this.cache.GetAll()
				.OrderBy(book => book.Title)
				.Skip((pagedListParameters.PageNumber - 1) * pagedListParameters.PageSize)
				.Take(pagedListParameters.PageSize)
				.ToList();
		}

		public IEnumerable<Book> GetBooksByTitle(string title, PagedListParameters pagedListParameters)
		{
			return this.cache.GetAll()
				.Where(book => book.Title.Contains(title))
				.OrderBy(book => book.Title)
				.Skip((pagedListParameters.PageNumber - 1) * pagedListParameters.PageSize)
				.Take(pagedListParameters.PageSize)
				.ToList();
		}

		public IEnumerable<Book> GetBooksByAuthor(string author, PagedListParameters pagedListParameters)
		{
			return this.cache.GetAll()
				.Where(book => book.Authors.Any(authorBook => authorBook.Name.Contains(author)))
				.OrderBy(book => book.Title)
				.Skip((pagedListParameters.PageNumber - 1) * pagedListParameters.PageSize)
				.Take(pagedListParameters.PageSize)
				.ToList();
		}

		public IEnumerable<Book> GetBooksByCategory(string category, PagedListParameters pagedListParameters)
		{
			return this.cache.GetAll()
				.Where(book => book.Сategory.Contains(category))
				.OrderBy(book => book.Title)
				.Skip((pagedListParameters.PageNumber - 1) * pagedListParameters.PageSize)
				.Take(pagedListParameters.PageSize)
				.ToList();
		}

		#endregion

		#region Конструктор

		/// <summary>
		/// 
		/// </summary>
		/// /// <param name="cache">Кеш книг.</param>
		public BookStore(IBookCache cache) 
		{
			this.logger = LogManager.GetCurrentClassLogger();
			this.logger.Trace("Init book store.");
			this.cache = cache;

			if (File.Exists(Directory.GetCurrentDirectory() + dataPathPrefix))
			{
				var serializer = new JsonSerializer();
				using (var reader = new StreamReader(Directory.GetCurrentDirectory() + dataPathPrefix))
				using (var jsonReader = new JsonTextReader(reader))
				{
					var books = serializer.Deserialize<IEnumerable<Book>>(jsonReader) ?? Enumerable.Empty<Book>();
					foreach (var book in books)
						this.cache.AddOrUpdate(book.Id, book);
				}

				this.logger.Trace("Load books is complete.");
			}
		}

		#endregion
	}
}
