﻿using System.Threading.Tasks;
using NoNonense.Application.Features.ExtendedAttributes.Commands.AddEdit;
using NoNonense.Domain.Entities.ExtendedAttributes;
using NoNonense.Domain.Entities.Misc;
using NoNonense.Server.Controllers.Utilities.ExtendedAttributes.Base;
using NoNonense.Shared.Constants.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NoNonense.Server.Controllers.Utilities.ExtendedAttributes.Misc
{
    public class DocumentExtendedAttributesController : ExtendedAttributesController<int, int, Document, DocumentExtendedAttribute>
    {
        [Authorize(Policy = Permissions.DocumentExtendedAttributes.View)]
        public override Task<IActionResult> GetAll()
        {
            return base.GetAll();
        }

        [Authorize(Policy = Permissions.DocumentExtendedAttributes.View)]
        public override Task<IActionResult> GetAllByEntityId(int entityId)
        {
            return base.GetAllByEntityId(entityId);
        }

        [Authorize(Policy = Permissions.DocumentExtendedAttributes.View)]
        public override Task<IActionResult> GetById(int id)
        {
            return base.GetById(id);
        }

        [Authorize(Policy = Permissions.DocumentExtendedAttributes.Create)]
        public override Task<IActionResult> Post(AddEditExtendedAttributeCommand<int, int, Document, DocumentExtendedAttribute> command)
        {
            return base.Post(command);
        }

        [Authorize(Policy = Permissions.DocumentExtendedAttributes.Delete)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }

        [Authorize(Policy = Permissions.DocumentExtendedAttributes.Export)]
        public override Task<IActionResult> Export(string searchString = "", int entityId = default, bool includeEntity = false, bool onlyCurrentGroup = false, string currentGroup = "")
        {
            return base.Export(searchString, entityId, includeEntity, onlyCurrentGroup, currentGroup);
        }
    }
}