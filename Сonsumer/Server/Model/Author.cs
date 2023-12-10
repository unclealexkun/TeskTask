using Newtonsoft.Json;

namespace Server.Model
{
	/// <summary>
	/// Автор.
	/// </summary>
	public class Author
	{
		/// <summary>
		/// Фамилия и Имя.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// Язык, на котором пишет автор.
		/// </summary>
		[JsonProperty("lang")]
		public string Language { get; set; }
	}
}
