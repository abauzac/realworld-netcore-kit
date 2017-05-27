using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using Sandbox.Server.DomainObjects.Interfaces.Handlers.Abstract;
using Sandbox.Server.DomainObjects.Interfaces.Models.Abstract;
using Sandbox.Server.DomainObjects.Interfaces.Repositories.Abstract;

namespace Sandbox.Server.BusinessLogic.Handlers.Abstract
{
    public abstract class EntityHandler<TE, TER> : IEntityHandler<TE>
      where TE: IEntity
      where TER: IEntityRepository<TE>
    {
        protected readonly TER _repository;

        protected EntityHandler(TER repository)
        {
            _repository = repository;
        }

        public virtual async Task<TE> Create(TE instance)
        {
            return await _repository.Create(instance);
        }

        public virtual async Task<TE> Retrieve(ObjectId id)
        {
            return await _repository.Retrieve(id);
        }

        public virtual async Task<TE> Update(TE instance)
        {
            return await _repository.Update(instance);
        }

        public virtual void Delete(TE instance)
        {
             _repository.Delete(instance);
        }

        public virtual async Task<IEnumerable<TE>> RetrieveAll()
        {
            return await _repository.RetrieveAll();
        }
    }
}