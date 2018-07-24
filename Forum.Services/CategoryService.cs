using System.Linq;
using AutoMapper;
using Forum.Data;
using Forum.Models;
using Forum.Services.Contracts;
using AutoMapper.QueryableExtensions;

namespace Forum.Services
{
    public class CategoryService : ICategoryService
    {
	    private readonly ForumDbContext context;
	    private readonly IMapper mapper;

	    public CategoryService(ForumDbContext context, IMapper mapper)
	    {
		    this.context = context;
		    this.mapper = mapper;
	    }

	    public TModel ByName<TModel>(string name)
	    {
		    var category = context.Categories
				.Where(c => c.Name == name)
				.ProjectTo<TModel>(mapper.ConfigurationProvider)
			    .SingleOrDefault();

		    return category;
	    }

	    public TModel Create<TModel>(string name)
	    {
		    var category = new Category
		    {
				Name = name
		    };

		    context.Categories.Add(category);

		    context.SaveChanges();

		    var dto = mapper.Map<TModel>(category);

		    return dto;
	    }
    }
}
