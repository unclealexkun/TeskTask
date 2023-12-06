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
		private ConcurrentDictionary<string, Book> cache;

		#endregion

		#region IBookCache

		public bool Add(string key, Book value)
		{
			return this.cache.TryAdd(key, value);
		}

		public bool AddOrUpdate(string key, Book value)
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

		public Book Get(string key)
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

		public bool Remove(string key)
		{
			return this.cache.TryRemove(key, out Book value);
		}

		#endregion

		#region Конструктор

		/// <summary>
		/// Конструктор.
		/// </summary>
		public BookCache() 
		{
			this.cache = new ConcurrentDictionary<string, Book>();
		}

		#endregion
	}
}
