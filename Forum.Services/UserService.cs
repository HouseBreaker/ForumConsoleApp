using System;
using System.Linq;
using Forum.Data;
using Forum.Models;
using Forum.Services.Contracts;

namespace Forum.Services
{
    public class UserService : IUserService
    {
	    private readonly ForumDbContext context;

	    public UserService(ForumDbContext context)
	    {
		    this.context = context;
	    }

	    public User ById(int id)
	    {
		    var user = context.Users.Find(id);

		    return user;
	    }

	    public User ByUsername(string username)
	    {
		    var user = context.Users
			    .SingleOrDefault(u => u.Username == username);

		    return user;
	    }

	    public User ByUsernameAndPassword(string username, string password)
	    {
			var user = context.Users
			    .SingleOrDefault(u => u.Username == username && u.Password == password);

		    return user;
		}

	    public User Create(string username, string password)
	    {
		    var user = new User(username, password);

		    context.Users.Add(user);

		    context.SaveChanges();

		    return user;
	    }

	    public void Delete(int id)
	    {
		    var user = context.Users.Find(id);

		    context.Users.Remove(user);

		    context.SaveChanges();
	    }
    }
}
