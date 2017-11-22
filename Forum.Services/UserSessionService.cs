using Forum.Models;
using Forum.Services.Contracts;

namespace Forum.Services
{
	public class UserSessionService : IUserSessionService
	{
		private readonly IUserService userService;

		public UserSessionService(IUserService userService)
		{
			this.userService = userService;
		}

		public User User { get; private set; }

		public User Login(string username, string password)
		{
			this.User = userService.ByUsernameAndPassword(username, password);

			return this.User;
		}

		public void Logout() => this.User = null;

		public bool IsLoggedIn() => this.User != null;
	}
}
