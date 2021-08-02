using NowWhat.Application.Models.Chat;
using NowWhat.Application.Responses.Identity;
using NowWhat.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using NowWhat.Application.Interfaces.Chat;

namespace NowWhat.Client.Infrastructure.Managers.Communication
{
    public interface IChatManager : IManager
    {
        Task<IResult<IEnumerable<ChatUserResponse>>> GetChatUsersAsync();

        Task<IResult> SaveMessageAsync(ChatHistory<IChatUser> chatHistory);

        Task<IResult<IEnumerable<ChatHistoryResponse>>> GetChatHistoryAsync(string cId);
    }
}