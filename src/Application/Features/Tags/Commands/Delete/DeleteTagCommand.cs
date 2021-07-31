﻿using NoNonense.Application.Interfaces.Repositories;
using NoNonense.Domain.Entities.Catalog;
using NoNonense.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using NoNonense.Shared.Constants.Application;

namespace NoNonense.Application.Features.Tags.Commands.Delete
{
    public class DeleteTagCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    internal class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, Result<int>>
    {
        private readonly INoteRepository _noteRepository;
        private readonly IStringLocalizer<DeleteTagCommandHandler> _localizer;
        private readonly IUnitOfWork<int> _unitOfWork;

        public DeleteTagCommandHandler(IUnitOfWork<int> unitOfWork, INoteRepository noteRepository, IStringLocalizer<DeleteTagCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _noteRepository = noteRepository;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(DeleteTagCommand command, CancellationToken cancellationToken)
        {
            var isTagUsed = await _noteRepository.IsTagUsed(command.Id);
            if (!isTagUsed)
            {
                var tag = await _unitOfWork.Repository<Tag>().GetByIdAsync(command.Id);
                if (tag != null)
                {
                    await _unitOfWork.Repository<Tag>().DeleteAsync(tag);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllTagsCacheKey);
                    return await Result<int>.SuccessAsync(tag.Id, _localizer["Tag Deleted"]);
                }
                else
                {
                    return await Result<int>.FailAsync(_localizer["Tag Not Found!"]);
                }
            }
            else
            {
                return await Result<int>.FailAsync(_localizer["Deletion Not Allowed"]);
            }
        }
    }
}