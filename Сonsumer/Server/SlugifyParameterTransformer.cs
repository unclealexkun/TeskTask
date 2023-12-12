using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Routing;

namespace Server
{
	/// <summary>
	/// Трансформатор параметров к формату Slugify.
	/// </summary>
	public sealed class SlugifyParameterTransformer : IOutboundParameterTransformer
	{
		/// <summary>
		/// Преобразование исходящего трафика.
		/// </summary>
		/// <param name="value">Входное значение.</param>
		/// <returns>Строка в формате Slugify.</returns>
		public string? TransformOutbound(object? value)
		{
			if (value == null) { return null; }
			string? str = value.ToString();
			if (string.IsNullOrEmpty(str)) { return null; }

			return Regex.Replace(str, "([a-z])([A-Z])", "$1-$2").ToLower();
		}
	}
}
