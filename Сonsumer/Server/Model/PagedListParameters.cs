namespace Server.Model
{
	/// <summary>
	/// Параметры для пагинации.
	/// </summary>
	public class PagedListParameters
	{
		#region Константы

		/// <summary>
		/// Максимальный размер страницы.
		/// </summary>
		const int maxPageSize = 50;

		#endregion

		#region Поля и свойства

		/// <summary>
		/// Размер страницы.
		/// </summary>
		private int pageSize = 10;

		/// <summary>
		/// Номер страницы.
		/// </summary>
		public int PageNumber { get; set; } = 1;

		/// <summary>
		/// Размер страницы.
		/// </summary>
		public int PageSize
		{
			get
			{
				return this.pageSize;
			}
			set
			{
				this.pageSize = (value > maxPageSize) ? maxPageSize : value;
			}
		}

		#endregion

	}
}
