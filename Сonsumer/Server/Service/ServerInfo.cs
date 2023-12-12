using System.Diagnostics;
using System.Reflection;

namespace Server.Service
{
	/// <summary>
	/// Версия сервера.
	/// </summary>
	public class ServerInfo
	{
		#region Поля и свойства

		/// <summary>
		/// Lazy реализация.
		/// </summary>
		private static readonly Lazy<ServerInfo> lazy 
			= new Lazy<ServerInfo>(() => new ServerInfo());

		/// <summary>
		/// Получить инстанс.
		/// </summary>
		/// <returns>Инстранс.</returns>
		public static ServerInfo GetInstance => lazy.Value;

		#endregion

		#region Методы

		/// <summary>
		/// Получить версию сервера.
		/// </summary>
		/// <returns>Версию сервера.</returns>
		public string GetVersion()
		{
			var assembly = Assembly.GetEntryAssembly();
			if (assembly != null)
			{
				var assemblyName = assembly.GetName();
				var version = assemblyName.Version;
				return version != null
					? version.ToString()
					: string.Empty;
			}
			return string.Empty;
		}

		/// <summary>
		/// Получить текущую нагрузку по процессору.
		/// </summary>
		/// <returns>Текущая нагрузка по процессору.</returns>
		public string GetCurrentCpuUsage()
		{
			var cpuCounter = new PerformanceCounter()
			{
				CategoryName = "Processor",
				CounterName = "% Processor Time",
				InstanceName = "_Total"
			};

			return $"Processor {cpuCounter.NextValue()}% ";
		}

		/// <summary>
		/// Получить использование памяти.
		/// </summary>
		/// <returns>Текущее использование памяти.</returns>
		public string GetAvailableRam()
		{
			var ramCounter = new PerformanceCounter()
			{
				CategoryName = "Memory",
				CounterName = "Available MBytes"
			};

			return $"Memory {ramCounter.NextValue()} Mb ";
		}

		#endregion

		#region Конструктор

		/// <summary>
		/// Конструктор.
		/// </summary>
		private ServerInfo() { }

		#endregion
	}
}
