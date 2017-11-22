using System;
using System.IO;
using Forum.Data;
using Forum.Services;
using Forum.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Forum.App
{
	public class Startup
	{
		public static void Main(string[] args)
		{
			var serviceProvider = ConfigureServices();

			var engine = new Engine(serviceProvider);
			engine.Run();
		}

		private static IServiceProvider ConfigureServices()
		{
			var serviceCollection = new ServiceCollection();

			var config = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

			serviceCollection.AddDbContext<ForumDbContext>(options =>
				options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
			);

			serviceCollection.AddTransient<IDatabaseInitializerService, DatabaseInitializerService>();
			serviceCollection.AddTransient<IUserService, UserService>();
			serviceCollection.AddTransient<IPostService, PostService>();
			serviceCollection.AddTransient<ICategoryService, CategoryService>();
			serviceCollection.AddTransient<IReplyService, ReplyService>();

			serviceCollection.AddSingleton<IUserSessionService, UserSessionService>();

			var serviceProvider = serviceCollection.BuildServiceProvider();

			return serviceProvider;
		}
	}
}