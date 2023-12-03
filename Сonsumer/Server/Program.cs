using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;

namespace Server
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			var logger = LogManager.GetCurrentClassLogger();

			try
			{
				var configuration = new ConfigurationBuilder()
				 .SetBasePath(Directory.GetCurrentDirectory())
				 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				 .Build();

				CreateHostBuilder(args, configuration).Build().RunAsync();
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

		public static IHostBuilder CreateHostBuilder(string[] args, IConfigurationRoot configuration) =>
				Host.CreateDefaultBuilder(args)
					.ConfigureServices(services =>
					{
						services.AddLogging(log => 
						{
							log.ClearProviders();
							log.AddConfiguration(configuration);
						});
						//services.AddHostedService<>();
					});
	}
}
