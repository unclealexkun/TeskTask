namespace Server.Model
{
	/// <summary>
	/// Книга.
	/// </summary>
	public class Book
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Заголовок.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Раздел.
		/// </summary>
		public string Сategory { get; set; }

		/// <summary>
		/// Авторы.
		/// </summary>
		public Author[] Authors { get; set; }

		/// <summary>
		/// Дата публикации.
		/// </summary>
		public DateTime PublicationDate { get; set; }

		/// <summary>
		/// Язык.
		/// </summary>
		public string Language { get; set; }

		/// <summary>
		/// Количество страниц.
		/// </summary>
		public int Pages { get; set; }

		/// <summary>
		/// Возрастной лимит.
		/// </summary>
		public int AgeLimit { get; set; }
	}
}
