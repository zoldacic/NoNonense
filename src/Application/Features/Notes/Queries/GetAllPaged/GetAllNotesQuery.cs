using NowWhat.Application.Extensions;
using NowWhat.Application.Interfaces.Repositories;
using NowWhat.Application.Specifications.Catalog;
using NowWhat.Domain.Entities.Catalog;
using NowWhat.Shared.Wrapper;
using MediatR;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;

namespace NowWhat.Application.Features.Notes.Queries.GetAllPaged
{
    public class GetAllNotesQuery : IRequest<PaginatedResult<GetAllPagedNotesResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public string[] OrderBy { get; set; } // of the form fieldname [ascending|descending],fieldname [ascending|descending]...

        public GetAllNotesQuery(int pageNumber, int pageSize, string searchString, string orderBy)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SearchString = searchString;
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                OrderBy = orderBy.Split(',');
            }
        }
    }

    internal class GetAllNotesQueryHandler : IRequestHandler<GetAllNotesQuery, PaginatedResult<GetAllPagedNotesResponse>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;

        public GetAllNotesQueryHandler(IUnitOfWork<int> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginatedResult<GetAllPagedNotesResponse>> Handle(GetAllNotesQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Note, GetAllPagedNotesResponse>> expression = e => new GetAllPagedNotesResponse
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Rate = e.Rate,
                Barcode = e.Barcode,
                Tag = e.Tag.Name,
                TagId = e.TagId
            };
            var noteFilterSpec = new NoteFilterSpecification(request.SearchString);
            if (request.OrderBy?.Any() != true)
            {
                var data = await _unitOfWork.Repository<Note>().Entities
                   .Specify(noteFilterSpec)
                   .Select(expression)
                   .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                return data;
            }
            else
            {
                var ordering = string.Join(",", request.OrderBy); // of the form fieldname [ascending|descending], ...
                var data = await _unitOfWork.Repository<Note>().Entities
                   .Specify(noteFilterSpec)
                   .OrderBy(ordering) // require system.linq.dynamic.core
                   .Select(expression)
                   .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                return data;

            }
        }
    }
}