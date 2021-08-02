using AutoMapper;
using NowWhat.Application.Interfaces.Chat;
using NowWhat.Application.Models.Chat;
using NowWhat.Infrastructure.Models.Identity;

namespace NowWhat.Infrastructure.Mappings
{
    public class ChatHistoryProfile : Profile
    {
        public ChatHistoryProfile()
        {
            CreateMap<ChatHistory<IChatUser>, ChatHistory<BlazorHeroUser>>().ReverseMap();
        }
    }
}