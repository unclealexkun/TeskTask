using Server.Model;

namespace Server.Service
{
	/// <summary>
	/// Храненилище книг.
	/// </summary>
	public interface IBookStore
	{
		/// <summary>
		/// Получить все книжные категории.
		/// </summary>
		/// <returns>Книжные категории.</returns>
		public IEnumerable<string> GetBookCategories();

		/// <summary>
		/// Получить список всех книг.
		/// </summary>
		/// <returns>Список всех книг</returns>
		public IEnumerable<Book> GetAllBooks();

		/// <summary>
		/// Получить список всех книг по наименованию.
		/// </summary>
		/// <param name="title">Название книги.</param>
		/// <returns>Список всех книг по наименованию.</returns>
		public IEnumerable<Book> GetBooksByTitle(string title);

		/// <summary>
		/// Получить список всех книг по автору.
		/// </summary>
		/// <param name="author">Автор книги.</param>
		/// <returns>Список всех книг по автору.</returns>
		public IEnumerable<Book> GetBooksByAuthor(string author);

		/// <summary>
		/// Получить список всех книг по категориям.
		/// </summary>
		/// <param name="category">Категория книги.</param>
		/// <returns>Список всех книг по категориям.</returns>
		public IEnumerable<Book> GetBooksByCategory(string category);
	}
}
