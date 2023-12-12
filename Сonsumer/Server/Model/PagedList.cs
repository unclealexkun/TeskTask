namespace Server.Model
{
	/// <summary>
	/// Класс для пагинации.
	/// </summary>
	/// <typeparam name="T">Объекты для пагинации.</typeparam>
	public class PagedList<T>: List<T>
	{
		#region Поля и свойства

		/// <summary>
		/// Текущая страница.
		/// </summary>
		public int CurrentPage { get; private set; }

		/// <summary>
		/// Всего страниц.
		/// </summary>
		public int TotalPages { get; private set; }

		/// <summary>
		/// Размер страницы.
		/// </summary>
		public int PageSize { get; private set; }

		/// <summary>
		/// Всего элементов.
		/// </summary>
		public int TotalCount { get; private set; }

		/// <summary>
		/// Есть ли предидущая.
		/// </summary>
		public bool HasPrevious => CurrentPage > 1;

		/// <summary>
		/// Есть ли следующая.
		/// </summary>
		public bool HasNext => CurrentPage < TotalPages;

		#endregion

		#region Метод

		/// <summary>
		/// Преобразование к пагинации.
		/// </summary>
		/// <param name="source">Коллекция источник.</param>
		/// <param name="pageNumber">Номер страницы.</param>
		/// <param name="pageSize">Размер страницы.</param>
		/// <returns></returns>
		public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
		{
			var count = source.Count();
			var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
			return new PagedList<T>(items, count, pageNumber, pageSize);
		}

		#endregion

		#region Конструктор

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="items">Коллекция.</param>
		/// <param name="count">Количество элеметов колекции.</param>
		/// <param name="pageNumber">Номер страницы.</param>
		/// <param name="pageSize">Размер страницы.</param>
		public PagedList(List<T> items, int count, int pageNumber, int pageSize)
		{
			TotalCount = count;
			PageSize = pageSize;
			CurrentPage = pageNumber;
			TotalPages = (int)Math.Ceiling(count / (double)pageSize);
			AddRange(items);
		}

		#endregion
	}
}
