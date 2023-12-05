using Newtonsoft.Json;

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
		[JsonProperty("id")]
		public Guid Id { get; set; }

		/// <summary>
		/// Заголовок.
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		/// Раздел.
		/// </summary>
		[JsonProperty("category")]
		public string Сategory { get; set; }

		/// <summary>
		/// Авторы.
		/// </summary>
		[JsonProperty("authors")]
		public Author[] Authors { get; set; }

		/// <summary>
		/// Дата публикации.
		/// </summary>
		[JsonProperty("publicationDate")]
		public int PublicationDate { get; set; }

		/// <summary>
		/// Язык.
		/// </summary>
		[JsonProperty("lang")]
		public string Language { get; set; }

		/// <summary>
		/// Количество страниц.
		/// </summary>
		[JsonProperty("pages")]
		public int Pages { get; set; }

		/// <summary>
		/// Возрастной лимит.
		/// </summary>
		[JsonProperty("ageLimit")]
		public int AgeLimit { get; set; }
	}
}
