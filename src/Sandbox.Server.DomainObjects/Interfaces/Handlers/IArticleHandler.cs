using System.Threading.Tasks;
using Sandbox.Server.DomainObjects.Interfaces.Handlers.Abstract;
using Sandbox.Server.DomainObjects.Models;

namespace Sandbox.Server.DomainObjects.Interfaces.Handlers
{
  public interface IArticleHandler: IEntityHandler<Article>
  {
        Task<Article> UpdateForSlug(string slug, Article entity);
  }
}