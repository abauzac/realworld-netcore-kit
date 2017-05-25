using System.Collections.Generic;
using System.Threading.Tasks;
using Sandbox.Server.DomainObjects.Interfaces.Repositories.Abstract;
using Sandbox.Server.DomainObjects.Models;

namespace Sandbox.Server.DomainObjects.Interfaces.Repositories
{
  public interface ICommentRepository : IEntityRepository<Comment>
  {
        Task<List<Comment>> RetrieveAllForSlug(string slug);
  }
}