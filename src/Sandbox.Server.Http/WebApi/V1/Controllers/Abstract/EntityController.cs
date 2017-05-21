using System;
using Microsoft.AspNetCore.Mvc;
using Sandbox.Server.DomainObjects.Interfaces.Handlers.Abstract;
using Sandbox.Server.DomainObjects.Interfaces.Models.Abstract;

namespace Sandbox.Server.Http.WebApi.V1.Controllers.Abstract
{
    public abstract class EntityController<TE, TEH> : Controller
      where TE : IEntity
      where TEH : IEntityHandler<TE>
    {
        protected readonly TEH _handler;

        protected EntityController(TEH handler)
        {
            _handler = handler;
        }

      protected string GenerateUrl(TE entity)
      {
        return GenerateUrl(entity.GetType().Name, entity.Id.ToString());
      }

      protected string GenerateUrl(string typeName, string id)
      {
        return Url.Action("Get", typeName, new {id = id}, Request.Scheme);
      }
    }
}