using AutoMapper;
using Chat.Api.Core.Domains;
using Chat.ApplicationService.Dtos;
using Chat.Core.Domains;

namespace Chat.Api.Extensions
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<ChatGroup, ChatGroupDto>();
            CreateMap<ChatGroup, ChatGroupDto>().ReverseMap();

            CreateMap<User, UserDto>();
            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<UserGroup, UserGroupDto>();
            CreateMap<UserGroup, UserGroupDto>().ReverseMap();

            CreateMap<ChatMessage, ChatMessageDto>();
            CreateMap<ChatMessage, ChatMessageDto>().ReverseMap();
        }
    }
}
