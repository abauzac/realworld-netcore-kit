using System.Collections.Generic;
using System.Threading.Tasks;
using Sandbox.Server.DomainObjects.Interfaces.Handlers.Abstract;
using Sandbox.Server.DomainObjects.Models;

namespace Sandbox.Server.DomainObjects.Interfaces.Handlers
{
    public interface ICommentHandler : IEntityHandler<Comment>
    {
        Task<bool> DeleteForCommentId(string id);
    }
}