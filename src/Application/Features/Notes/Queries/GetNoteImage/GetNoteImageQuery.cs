using NowWhat.Application.Interfaces.Repositories;
using NowWhat.Domain.Entities.Catalog;
using NowWhat.Shared.Wrapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NowWhat.Application.Features.Notes.Queries.GetNoteImage
{
    public class GetNoteImageQuery : IRequest<Result<string>>
    {
        public int Id { get; set; }

        public GetNoteImageQuery(int noteId)
        {
            Id = noteId;
        }
    }

    internal class GetNoteImageQueryHandler : IRequestHandler<GetNoteImageQuery, Result<string>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;

        public GetNoteImageQueryHandler(IUnitOfWork<int> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> Handle(GetNoteImageQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repository<Note>().Entities.Where(p => p.Id == request.Id).Select(a => a.ImageDataURL).FirstOrDefaultAsync(cancellationToken);
            return await Result<string>.SuccessAsync(data: data);
        }
    }
}