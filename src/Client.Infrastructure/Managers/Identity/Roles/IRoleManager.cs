﻿using NowWhat.Application.Requests.Identity;
using NowWhat.Application.Responses.Identity;
using NowWhat.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NowWhat.Client.Infrastructure.Managers.Identity.Roles
{
    public interface IRoleManager : IManager
    {
        Task<IResult<List<RoleResponse>>> GetRolesAsync();

        Task<IResult<string>> SaveAsync(RoleRequest role);

        Task<IResult<string>> DeleteAsync(string id);

        Task<IResult<PermissionResponse>> GetPermissionsAsync(string roleId);

        Task<IResult<string>> UpdatePermissionsAsync(PermissionRequest request);
    }
}