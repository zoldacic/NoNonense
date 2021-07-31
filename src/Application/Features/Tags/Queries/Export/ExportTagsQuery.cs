using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NoNonense.Application.Extensions;
using NoNonense.Application.Interfaces.Repositories;
using NoNonense.Application.Interfaces.Services;
using NoNonense.Application.Specifications.Catalog;
using NoNonense.Domain.Entities.Catalog;
using NoNonense.Shared.Wrapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace NoNonense.Application.Features.Tags.Queries.Export
{
    public class ExportTagsQuery : IRequest<Result<string>>
    {
        public string SearchString { get; set; }

        public ExportTagsQuery(string searchString = "")
        {
            SearchString = searchString;
        }
    }

    internal class ExportTagsQueryHandler : IRequestHandler<ExportTagsQuery, Result<string>>
    {
        private readonly IExcelService _excelService;
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IStringLocalizer<ExportTagsQueryHandler> _localizer;

        public ExportTagsQueryHandler(IExcelService excelService
            , IUnitOfWork<int> unitOfWork
            , IStringLocalizer<ExportTagsQueryHandler> localizer)
        {
            _excelService = excelService;
            _unitOfWork = unitOfWork;
            _localizer = localizer;
        }

        public async Task<Result<string>> Handle(ExportTagsQuery request, CancellationToken cancellationToken)
        {
            var tagFilterSpec = new TagFilterSpecification(request.SearchString);
            var tags = await _unitOfWork.Repository<Tag>().Entities
                .Specify(tagFilterSpec)
                .ToListAsync(cancellationToken);
            var data = await _excelService.ExportAsync(tags, mappers: new Dictionary<string, Func<Tag, object>>
            {
                { _localizer["Id"], item => item.Id },
                { _localizer["Name"], item => item.Name },
                { _localizer["Description"], item => item.Description },
                { _localizer["Tax"], item => item.Tax }
            }, sheetName: _localizer["Tags"]);

            return await Result<string>.SuccessAsync(data: data);
        }
    }
}
