using Server.Model;

namespace Server.Cash
{
	/// <summary>
	/// Интерфейс для кеша.
	/// </summary>
	public interface IBookCash
	{
		/// <summary>
		/// Добавить объект в кеш.
		/// </summary>
		/// <param name="key">Ключ, по которому будет добавлен объект в кеш.</param>
		/// <param name="value">Объект, который будет добавлен в кеш.</param>
		/// <returns>True - если успешно добавлен объект, иначе False.</returns>
		bool Add(Guid key, Book value);

		/// <summary>
		/// Добавить или обновить объект в кеш.
		/// </summary>
		/// <param name="key">Ключ, по которому будет добавлен или обновлён объект в кеше.</param>
		/// <param name="value">Объект, который будет добавлен или обновлён в кеше.</param>
		/// <returns>True - если успешно добавлен или обновлён объект, иначе False.</returns>
		bool AddOrUpdate(Guid key, Book value);

		/// <summary>
		/// Получить объект из кеша.
		/// </summary>
		/// <param name="key">Ключ, по которому будет получен объект из кеша.</param>
		/// <returns>Объект по ключу.</returns>
		Book Get(Guid key);

		/// <summary>
		/// Получить объекты из кеша.
		/// </summary>
		/// <returns>Объекты из кеша.</returns>
		IEnumerable<Book> GetAll();

		/// <summary>
		/// Удалить объект из кеша.
		/// </summary>
		/// <param name="key">Ключ, по которому будет удалён объект из кеша.</param>
		/// <returns>True - если успешно удалиться объект, иначе False.</returns>
		bool Remove(Guid key);

		/// <summary>
		/// Очистить кеш.
		/// </summary>
		void Clear();
	}
}
