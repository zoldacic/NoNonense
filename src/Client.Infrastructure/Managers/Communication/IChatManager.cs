using NoNonense.Application.Models.Chat;
using NoNonense.Application.Responses.Identity;
using NoNonense.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoNonense.Application.Interfaces.Chat;

namespace NoNonense.Client.Infrastructure.Managers.Communication
{
    public interface IChatManager : IManager
    {
        Task<IResult<IEnumerable<ChatUserResponse>>> GetChatUsersAsync();

        Task<IResult> SaveMessageAsync(ChatHistory<IChatUser> chatHistory);

        Task<IResult<IEnumerable<ChatHistoryResponse>>> GetChatHistoryAsync(string cId);
    }
}