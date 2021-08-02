using NowWhat.Application.Interfaces.Repositories;
using NowWhat.Application.Interfaces.Services;
using NowWhat.Domain.Entities.Catalog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NowWhat.Application.Extensions;
using NowWhat.Application.Specifications.Catalog;
using NowWhat.Shared.Wrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace NowWhat.Application.Features.Notes.Queries.Export
{
    public class ExportNotesQuery : IRequest<Result<string>>
    {
        public string SearchString { get; set; }

        public ExportNotesQuery(string searchString = "")
        {
            SearchString = searchString;
        }
    }

    internal class ExportNotesQueryHandler : IRequestHandler<ExportNotesQuery, Result<string>>
    {
        private readonly IExcelService _excelService;
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IStringLocalizer<ExportNotesQueryHandler> _localizer;

        public ExportNotesQueryHandler(IExcelService excelService
            , IUnitOfWork<int> unitOfWork
            , IStringLocalizer<ExportNotesQueryHandler> localizer)
        {
            _excelService = excelService;
            _unitOfWork = unitOfWork;
            _localizer = localizer;
        }

        public async Task<Result<string>> Handle(ExportNotesQuery request, CancellationToken cancellationToken)
        {
            var noteFilterSpec = new NoteFilterSpecification(request.SearchString);
            var notes = await _unitOfWork.Repository<Note>().Entities
                .Specify(noteFilterSpec)
                .ToListAsync( cancellationToken);
            var data = await _excelService.ExportAsync(notes, mappers: new Dictionary<string, Func<Note, object>>
            {
                { _localizer["Id"], item => item.Id },
                { _localizer["Name"], item => item.Name },
                { _localizer["Barcode"], item => item.Barcode },
                { _localizer["Description"], item => item.Description },
                { _localizer["Rate"], item => item.Rate }
            }, sheetName: _localizer["Notes"]);

            return await Result<string>.SuccessAsync(data: data);
        }
    }
}