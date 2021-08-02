using NowWhat.Application.Responses.Identity;
using NowWhat.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using NowWhat.Application.Interfaces.Chat;
using NowWhat.Application.Models.Chat;

namespace NowWhat.Application.Interfaces.Services
{
    public interface IChatService
    {
        Task<Result<IEnumerable<ChatUserResponse>>> GetChatUsersAsync(string userId);

        Task<IResult> SaveMessageAsync(ChatHistory<IChatUser> message);

        Task<Result<IEnumerable<ChatHistoryResponse>>> GetChatHistoryAsync(string userId, string contactId);
    }
}