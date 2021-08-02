using NowWhat.Application.Features.Tags.Queries.GetAll;
using NowWhat.Application.Features.Notes.Commands.AddEdit;
using NowWhat.Application.Requests;
using NowWhat.Client.Extensions;
using NowWhat.Shared.Constants.Application;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Blazored.FluentValidation;
using NowWhat.Client.Infrastructure.Managers.Catalog.Tag;
using NowWhat.Client.Infrastructure.Managers.Catalog.Note;

namespace NowWhat.Client.Pages.Catalog
{
    public partial class AddEditNoteModal
    {
        [Inject] private INoteManager NoteManager { get; set; }
        [Inject] private ITagManager TagManager { get; set; }

        [Parameter] public AddEditNoteCommand AddEditNoteModel { get; set; } = new();
        [CascadingParameter] private HubConnection HubConnection { get; set; }
        [CascadingParameter] private MudDialogInstance MudDialog { get; set; }

        private FluentValidationValidator _fluentValidationValidator;
        private bool Validated => _fluentValidationValidator.Validate(options => { options.IncludeAllRuleSets(); });
        private List<GetAllTagsResponse> _tags = new();

        public void Cancel()
        {
            MudDialog.Cancel();
        }

        private async Task SaveAsync()
        {
            var response = await NoteManager.SaveAsync(AddEditNoteModel);
            if (response.Succeeded)
            {
                _snackBar.Add(response.Messages[0], Severity.Success);
                await HubConnection.SendAsync(ApplicationConstants.SignalR.SendUpdateDashboard);
                MudDialog.Close();
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                }
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await LoadDataAsync();
            HubConnection = HubConnection.TryInitialize(_navigationManager);
            if (HubConnection.State == HubConnectionState.Disconnected)
            {
                await HubConnection.StartAsync();
            }
        }

        private async Task LoadDataAsync()
        {
            await LoadImageAsync();
            await LoadTagsAsync();
        }

        private async Task LoadTagsAsync()
        {
            var data = await TagManager.GetAllAsync();
            if (data.Succeeded)
            {
                _tags = data.Data;
            }
        }

        private async Task LoadImageAsync()
        {
            var data = await NoteManager.GetNoteImageAsync(AddEditNoteModel.Id);
            if (data.Succeeded)
            {
                var imageData = data.Data;
                if (!string.IsNullOrEmpty(imageData))
                {
                    AddEditNoteModel.ImageDataURL = imageData;
                }
            }
        }

        private void DeleteAsync()
        {
            AddEditNoteModel.ImageDataURL = null;
            AddEditNoteModel.UploadRequest = new UploadRequest();
        }

        private IBrowserFile _file;

        private async Task UploadFiles(InputFileChangeEventArgs e)
        {
            _file = e.File;
            if (_file != null)
            {
                var extension = Path.GetExtension(_file.Name);
                var format = "image/png";
                var imageFile = await e.File.RequestImageFileAsync(format, 400, 400);
                var buffer = new byte[imageFile.Size];
                await imageFile.OpenReadStream().ReadAsync(buffer);
                AddEditNoteModel.ImageDataURL = $"data:{format};base64,{Convert.ToBase64String(buffer)}";
                AddEditNoteModel.UploadRequest = new UploadRequest { Data = buffer, UploadType = Application.Enums.UploadType.Note, Extension = extension };
            }
        }

        private async Task<IEnumerable<int>> SearchTags(string value)
        {
            // In real life use an asynchronous function for fetching data from an api.
            await Task.Delay(5);

            // if text is null or empty, show complete list
            if (string.IsNullOrEmpty(value))
                return _tags.Select(x => x.Id);

            return _tags.Where(x => x.Name.Contains(value, StringComparison.InvariantCultureIgnoreCase))
                .Select(x => x.Id);
        }
    }
}