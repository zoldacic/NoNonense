using System.ComponentModel.DataAnnotations;
using AutoMapper;
using NoNonense.Application.Interfaces.Repositories;
using NoNonense.Application.Interfaces.Services;
using NoNonense.Application.Requests;
using NoNonense.Domain.Entities.Catalog;
using NoNonense.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NoNonense.Application.Features.Notes.Commands.AddEdit
{
    public partial class AddEditNoteCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Barcode { get; set; }
        [Required]
        public string Description { get; set; }
        public string ImageDataURL { get; set; }
        [Required]
        public decimal Rate { get; set; }
        [Required]
        public int TagId { get; set; }
        public UploadRequest UploadRequest { get; set; }
    }

    internal class AddEditNoteCommandHandler : IRequestHandler<AddEditNoteCommand, Result<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IUploadService _uploadService;
        private readonly IStringLocalizer<AddEditNoteCommandHandler> _localizer;

        public AddEditNoteCommandHandler(IUnitOfWork<int> unitOfWork, IMapper mapper, IUploadService uploadService, IStringLocalizer<AddEditNoteCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _uploadService = uploadService;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(AddEditNoteCommand command, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.Repository<Note>().Entities.Where(p => p.Id != command.Id)
                .AnyAsync(p => p.Barcode == command.Barcode, cancellationToken))
            {
                return await Result<int>.FailAsync(_localizer["Barcode already exists."]);
            }

            var uploadRequest = command.UploadRequest;
            if (uploadRequest != null)
            {
                uploadRequest.FileName = $"P-{command.Barcode}{uploadRequest.Extension}";
            }

            if (command.Id == 0)
            {
                var note = _mapper.Map<Note>(command);
                if (uploadRequest != null)
                {
                    note.ImageDataURL = _uploadService.UploadAsync(uploadRequest);
                }
                await _unitOfWork.Repository<Note>().AddAsync(note);
                await _unitOfWork.Commit(cancellationToken);
                return await Result<int>.SuccessAsync(note.Id, _localizer["Note Saved"]);
            }
            else
            {
                var note = await _unitOfWork.Repository<Note>().GetByIdAsync(command.Id);
                if (note != null)
                {
                    note.Name = command.Name ?? note.Name;
                    note.Description = command.Description ?? note.Description;
                    if (uploadRequest != null)
                    {
                        note.ImageDataURL = _uploadService.UploadAsync(uploadRequest);
                    }
                    note.Rate = (command.Rate == 0) ? note.Rate : command.Rate;
                    note.TagId = (command.TagId == 0) ? note.TagId : command.TagId;
                    await _unitOfWork.Repository<Note>().UpdateAsync(note);
                    await _unitOfWork.Commit(cancellationToken);
                    return await Result<int>.SuccessAsync(note.Id, _localizer["Note Updated"]);
                }
                else
                {
                    return await Result<int>.FailAsync(_localizer["Note Not Found!"]);
                }
            }
        }
    }
}