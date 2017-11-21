using System;
using Forum.Data;
using Forum.Services;
using Forum.Services.Contracts;
using Microsoft.EntityFrameworkCore;
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

			serviceCollection.AddDbContext<ForumDbContext>(options =>
				options.UseSqlServer(Configuration.ConnectionString)
			);

			serviceCollection.AddTransient<IDatabaseInitializerService, DatabaseInitializerService>();
			serviceCollection.AddTransient<IUserService, UserService>();
			serviceCollection.AddTransient<IPostService, PostService>();
			serviceCollection.AddTransient<ICategoryService, CategoryService>();
			serviceCollection.AddTransient<IReplyService, ReplyService>();

			var serviceProvider = serviceCollection.BuildServiceProvider();

			return serviceProvider;
		}
	}
}