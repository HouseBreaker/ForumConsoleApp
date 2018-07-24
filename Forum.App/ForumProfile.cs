using AutoMapper;
using Forum.App.Models;
using Forum.Models;

namespace Forum.App
{
    public class ForumProfile : Profile
    {
	    public ForumProfile()
	    {
		    CreateMap<User, User>();

			CreateMap<Post, PostDetailsDto>()
			    .ForMember(
				    replyDto => replyDto.ReplyCount,
				    opt => opt.MapFrom(post => post.Replies.Count));

		    CreateMap<Reply, ReplyDto>();
		}
    }
}
