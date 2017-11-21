using System.Linq;
using Forum.Data;
using Forum.Models;
using Forum.Services.Contracts;

namespace Forum.Services
{
    public class CategoryService : ICategoryService
    {
	    private readonly ForumDbContext context;

	    public CategoryService(ForumDbContext context)
	    {
		    this.context = context;
	    }

	    public Category ByName(string name)
	    {
		    var category = context.Categories
			    .SingleOrDefault(c => c.Name == name);

		    return category;
	    }

	    public Category Create(string name)
	    {
		    var category = new Category
		    {
				Name = name
		    };

		    context.Categories.Add(category);

		    context.SaveChanges();

		    return category;
	    }
    }
}
