using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;

namespace Server
{
	public class Program
	{

		#region Константы

		/// <summary>
		/// Порт сервера.
		/// </summary>
		private const int port = 5000;

		/// <summary>
		/// Адрес по которому будет доступен наш сервер.
		/// </summary>
		private readonly static Uri url = new Uri($"http://localhost:{port}/");

		/// <summary>
		/// Логгер.
		/// </summary>
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();

		#endregion

		public static void Main(string[] args)
		{
			logger.Debug("Init main");
			try
			{
				var config = new ConfigurationBuilder()
					 .SetBasePath(Directory.GetCurrentDirectory())
					 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
					 .Build();

				var host = new WebHostBuilder()
								.UseKestrel()
								.UseUrls(url.ToString())
								.UseStartup<Startup>()
								.ConfigureLogging(loggingBuilder =>
								{
									loggingBuilder.ClearProviders();
									loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
									loggingBuilder.AddNLog(config);
								})
								.Build();
				host.Run();
			}
			catch (Exception ex)
			{
				logger.Error(ex, "Stopped program because of exception");
				throw;
			}
			finally
			{
				LogManager.Shutdown();
			}
		}
	}
}
