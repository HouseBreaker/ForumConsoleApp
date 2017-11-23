using AutoMapper;
using Forum.App.Models;
using Forum.Models;

namespace Forum.App
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<User, User>();
			CreateMap<Post, PostDetailsViewModel>();
		}
	}
}
