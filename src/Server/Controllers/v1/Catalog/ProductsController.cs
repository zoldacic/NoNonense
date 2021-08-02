using NowWhat.Application.Features.Notes.Commands.AddEdit;
using NowWhat.Application.Features.Notes.Commands.Delete;
using NowWhat.Application.Features.Notes.Queries.Export;
using NowWhat.Application.Features.Notes.Queries.GetAllPaged;
using NowWhat.Application.Features.Notes.Queries.GetNoteImage;
using NowWhat.Shared.Constants.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace NowWhat.Server.Controllers.v1.Catalog
{
    public class NotesController : BaseApiController<NotesController>
    {
        /// <summary>
        /// Get All Notes
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchString"></param>
        /// <param name="orderBy"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.Notes.View)]
        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber, int pageSize, string searchString, string orderBy = null)
        {
            var notes = await _mediator.Send(new GetAllNotesQuery(pageNumber, pageSize, searchString, orderBy));
            return Ok(notes);
        }

        /// <summary>
        /// Get a Note Image by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.Notes.View)]
        [HttpGet("image/{id}")]
        public async Task<IActionResult> GetNoteImageAsync(int id)
        {
            var result = await _mediator.Send(new GetNoteImageQuery(id));
            return Ok(result);
        }

        /// <summary>
        /// Add/Edit a Note
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.Notes.Create)]
        [HttpPost]
        public async Task<IActionResult> Post(AddEditNoteCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        /// <summary>
        /// Delete a Note
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 OK response</returns>
        [Authorize(Policy = Permissions.Notes.Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteNoteCommand { Id = id }));
        }

        /// <summary>
        /// Search Notes and Export to Excel
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.Notes.Export)]
        [HttpGet("export")]
        public async Task<IActionResult> Export(string searchString = "")
        {
            return Ok(await _mediator.Send(new ExportNotesQuery(searchString)));
        }
    }
}