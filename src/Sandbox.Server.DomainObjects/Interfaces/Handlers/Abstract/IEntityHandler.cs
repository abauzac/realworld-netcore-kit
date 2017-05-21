using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sandbox.Server.DomainObjects.Interfaces.Models.Abstract;
using Sandbox.Server.DomainObjects.Models;

namespace Sandbox.Server.DomainObjects.Interfaces.Handlers.Abstract
{
    public interface IEntityHandler<TE>
      where TE: IEntity
    {
        Task<TE> Create(TE instance);
        Task<TE> Retrieve(Guid id);
        Task<TE> Update(TE instance);
        void Delete(TE instance);

        Task<IEnumerable<TE>> RetrieveAll();
    }
}