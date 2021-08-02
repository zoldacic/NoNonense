using NowWhat.Application.Interfaces.Repositories;
using NowWhat.Domain.Entities.Catalog;
using NowWhat.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;

namespace NowWhat.Application.Features.Notes.Commands.Delete
{
    public class DeleteNoteCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    internal class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, Result<int>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IStringLocalizer<DeleteNoteCommandHandler> _localizer;

        public DeleteNoteCommandHandler(IUnitOfWork<int> unitOfWork, IStringLocalizer<DeleteNoteCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(DeleteNoteCommand command, CancellationToken cancellationToken)
        {
            var note = await _unitOfWork.Repository<Note>().GetByIdAsync(command.Id);
            if (note != null)
            {
                await _unitOfWork.Repository<Note>().DeleteAsync(note);
                await _unitOfWork.Commit(cancellationToken);
                return await Result<int>.SuccessAsync(note.Id, _localizer["Note Deleted"]);
            }
            else
            {
                return await Result<int>.FailAsync(_localizer["Note Not Found!"]);
            }
        }
    }
}