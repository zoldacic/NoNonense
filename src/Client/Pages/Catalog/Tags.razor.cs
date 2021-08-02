﻿using NowWhat.Application.Features.Tags.Queries.GetAll;
using NowWhat.Client.Extensions;
using NowWhat.Shared.Constants.Application;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using NowWhat.Application.Features.Tags.Commands.AddEdit;
using NowWhat.Client.Infrastructure.Managers.Catalog.Tag;
using NowWhat.Shared.Constants.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.JSInterop;

namespace NowWhat.Client.Pages.Catalog
{
    public partial class Tags
    {
        [Inject] private ITagManager TagManager { get; set; }

        [CascadingParameter] private HubConnection HubConnection { get; set; }

        private List<GetAllTagsResponse> _tagList = new();
        private GetAllTagsResponse _tag = new();
        private string _searchString = "";
        private bool _dense = false;
        private bool _striped = true;
        private bool _bordered = false;

        private ClaimsPrincipal _currentUser;
        private bool _canCreateTags;
        private bool _canEditTags;
        private bool _canDeleteTags;
        private bool _canExportTags;
        private bool _canSearchTags;
        private bool _loaded;

        protected override async Task OnInitializedAsync()
        {
            _currentUser = await _authenticationManager.CurrentUser();
            _canCreateTags = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.Tags.Create)).Succeeded;
            _canEditTags = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.Tags.Edit)).Succeeded;
            _canDeleteTags = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.Tags.Delete)).Succeeded;
            _canExportTags = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.Tags.Export)).Succeeded;
            _canSearchTags = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.Tags.Search)).Succeeded;

            await GetTagsAsync();
            _loaded = true;
            HubConnection = HubConnection.TryInitialize(_navigationManager);
            if (HubConnection.State == HubConnectionState.Disconnected)
            {
                await HubConnection.StartAsync();
            }
        }

        private async Task GetTagsAsync()
        {
            var response = await TagManager.GetAllAsync();
            if (response.Succeeded)
            {
                _tagList = response.Data.ToList();
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                }
            }
        }

        private async Task Delete(int id)
        {
            string deleteContent = _localizer["Delete Content"];
            var parameters = new DialogParameters
            {
                {nameof(Shared.Dialogs.DeleteConfirmation.ContentText), string.Format(deleteContent, id)}
            };
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<Shared.Dialogs.DeleteConfirmation>(_localizer["Delete"], parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var response = await TagManager.DeleteAsync(id);
                if (response.Succeeded)
                {
                    await Reset();
                    await HubConnection.SendAsync(ApplicationConstants.SignalR.SendUpdateDashboard);
                    _snackBar.Add(response.Messages[0], Severity.Success);
                }
                else
                {
                    await Reset();
                    foreach (var message in response.Messages)
                    {
                        _snackBar.Add(message, Severity.Error);
                    }
                }
            }
        }

        private async Task ExportToExcel()
        {
            var response = await TagManager.ExportToExcelAsync(_searchString);
            if (response.Succeeded)
            {
                await _jsRuntime.InvokeVoidAsync("Download", new
                {
                    ByteArray = response.Data,
                    FileName = $"{nameof(Tags).ToLower()}_{DateTime.Now:ddMMyyyyHHmmss}.xlsx",
                    MimeType = ApplicationConstants.MimeTypes.OpenXml
                });
                _snackBar.Add(string.IsNullOrWhiteSpace(_searchString)
                    ? _localizer["Tags exported"]
                    : _localizer["Filtered Tags exported"], Severity.Success);
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                }
            }
        }

        private async Task InvokeModal(int id = 0)
        {
            var parameters = new DialogParameters();
            if (id != 0)
            {
                _tag = _tagList.FirstOrDefault(c => c.Id == id);
                if (_tag != null)
                {
                    parameters.Add(nameof(AddEditTagModal.AddEditTagModel), new AddEditTagCommand
                    {
                        Id = _tag.Id,
                        Name = _tag.Name,
                        Description = _tag.Description,
                        Tax = _tag.Tax
                    });
                }
            }
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<AddEditTagModal>(id == 0 ? _localizer["Create"] : _localizer["Edit"], parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                await Reset();
            }
        }

        private async Task Reset()
        {
            _tag = new GetAllTagsResponse();
            await GetTagsAsync();
        }

        private bool Search(GetAllTagsResponse tag)
        {
            if (string.IsNullOrWhiteSpace(_searchString)) return true;
            if (tag.Name?.Contains(_searchString, StringComparison.OrdinalIgnoreCase) == true)
            {
                return true;
            }
            if (tag.Description?.Contains(_searchString, StringComparison.OrdinalIgnoreCase) == true)
            {
                return true;
            }
            return false;
        }
    }
}