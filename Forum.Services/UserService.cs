using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Forum.Data;
using Forum.Models;
using Forum.Services.Contracts;

namespace Forum.Services
{
    public class UserService : IUserService
    {
	    private readonly ForumDbContext context;
	    private readonly IMapper mapper;

	    public UserService(ForumDbContext context, IMapper mapper)
	    {
		    this.context = context;
		    this.mapper = mapper;
	    }

	    public TModel ById<TModel>(int id)
	    {
		    var user = context.Users
				.Where(u => u.Id == id)
				.ProjectTo<TModel>(mapper.ConfigurationProvider)
				.SingleOrDefault();

		    return user;
	    }

	    public TModel ByUsername<TModel>(string username)
	    {
		    var user = context.Users
				.Where(u => u.Username == username)
				.ProjectTo<TModel>(mapper.ConfigurationProvider)
			    .SingleOrDefault();

		    return user;
	    }

	    public TModel ByUsernameAndPassword<TModel>(string username, string password)
	    {
			var user = context.Users
				.Where(u => u.Username == username && u.Password == password)
			    .ProjectTo<TModel>(mapper.ConfigurationProvider)
				.SingleOrDefault();

		    return user;
		}

	    public TModel Create<TModel>(string username, string password)
	    {
		    var user = new User(username, password);

		    context.Users.Add(user);

		    context.SaveChanges();

		    var userDto = mapper.Map<TModel>(user);

		    return userDto;
	    }

	    public void Delete(int id)
	    {
		    var user = context.Users.Find(id);

		    context.Users.Remove(user);

		    context.SaveChanges();
	    }
    }
}
