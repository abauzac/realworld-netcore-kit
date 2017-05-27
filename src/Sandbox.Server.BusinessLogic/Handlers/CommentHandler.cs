using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using Sandbox.Server.BusinessLogic.Handlers.Abstract;
using Sandbox.Server.DomainObjects.Interfaces.Handlers;
using Sandbox.Server.DomainObjects.Interfaces.Repositories;
using Sandbox.Server.DomainObjects.Interfaces.Repositories.Abstract;
using Sandbox.Server.DomainObjects.Models;

namespace Sandbox.Server.BusinessLogic.Handlers
{
    public class CommentHandler : EntityHandler<Comment, IEntityRepository<Comment>>, ICommentHandler
    {
        public CommentHandler(ICommentRepository repository) : base(repository)
        {
        }

        public async Task<bool> DeleteForCommentId(string id)
        {
            return await (this._repository as ICommentRepository).DeleteForId(new ObjectId(id));
        }

    }
}