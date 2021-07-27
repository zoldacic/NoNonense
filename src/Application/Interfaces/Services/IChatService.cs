using NoNonense.Application.Responses.Identity;
using NoNonense.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoNonense.Application.Interfaces.Chat;
using NoNonense.Application.Models.Chat;

namespace NoNonense.Application.Interfaces.Services
{
    public interface IChatService
    {
        Task<Result<IEnumerable<ChatUserResponse>>> GetChatUsersAsync(string userId);

        Task<IResult> SaveMessageAsync(ChatHistory<IChatUser> message);

        Task<Result<IEnumerable<ChatHistoryResponse>>> GetChatHistoryAsync(string userId, string contactId);
    }
}