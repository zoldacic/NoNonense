using AutoMapper;
using NoNonense.Application.Interfaces.Chat;
using NoNonense.Application.Models.Chat;
using NoNonense.Infrastructure.Models.Identity;

namespace NoNonense.Infrastructure.Mappings
{
    public class ChatHistoryProfile : Profile
    {
        public ChatHistoryProfile()
        {
            CreateMap<ChatHistory<IChatUser>, ChatHistory<BlazorHeroUser>>().ReverseMap();
        }
    }
}