using System.Collections.Concurrent;
using Server.Model;

namespace Server.Cache
{
	/// <summary>
	/// Кеш книг.
	/// </summary>
	public class BookCache : IBookCache
	{
		#region Поля и свойства

		/// <summary>
		/// Кеш книг.
		/// </summary>
		private ConcurrentDictionary<Guid, Book> cache = new ConcurrentDictionary<Guid, Book>();

		#endregion

		#region IBookCache

		public bool Add(Guid key, Book value)
		{
			return this.cache.TryAdd(key, value);
		}

		public bool AddOrUpdate(Guid key, Book value)
		{
			if (this.cache.ContainsKey(key))
			{
				this.cache.TryRemove(key, out Book removedValue);
			}
			return this.cache.TryAdd(key, value);
		}

		public void Clear()
		{
			this.cache.Clear();
		}

		public Book Get(Guid key)
		{
			if (this.cache.ContainsKey(key))
			{
				return this.cache[key];
			}
			return null;
		}

		public IEnumerable<Book> GetAll()
		{
			return this.cache.Select(c => c.Value);
		}

		public bool Remove(Guid key)
		{
			return this.cache.TryRemove(key, out Book value);
		}

		#endregion

		#region Конструктор

		/// <summary>
		/// Конструктор.
		/// </summary>
		private BookCache() { }

		#endregion
	}
}
