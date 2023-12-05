using System.Collections.Concurrent;
using Server.Model;

namespace Server.Cash
{
	/// <summary>
	/// Кеш книг.
	/// </summary>
	public class BookCash : IBookCash
	{
		#region Поля и свойства

		/// <summary>
		/// Кеш книг.
		/// </summary>
		private ConcurrentDictionary<Guid, Book> cash = new ConcurrentDictionary<Guid, Book>();

		#endregion

		#region IBookCash

		public bool Add(Guid key, Book value)
		{
			return this.cash.TryAdd(key, value);
		}

		public bool AddOrUpdate(Guid key, Book value)
		{
			if (this.cash.ContainsKey(key))
			{
				this.cash.TryRemove(key, out Book removedValue);
			}
			return this.cash.TryAdd(key, value);
		}

		public void Clear()
		{
			this.cash.Clear();
		}

		public Book Get(Guid key)
		{
			if (this.cash.ContainsKey(key))
			{
				return this.cash[key];
			}
			return null;
		}

		public IEnumerable<Book> GetAll()
		{
			return this.cash.Select(c => c.Value);
		}

		public bool Remove(Guid key)
		{
			return this.cash.TryRemove(key, out Book value);
		}

		#endregion

		#region Конструктор

		/// <summary>
		/// Конструктор.
		/// </summary>
		public BookCash() { }

		#endregion
	}
}
