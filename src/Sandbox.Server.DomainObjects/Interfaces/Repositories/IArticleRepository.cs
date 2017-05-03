using System.Collections.Generic;
using System.Threading.Tasks;
using Sandbox.Server.DomainObjects.Interfaces.Repositories.Abstract;
using Sandbox.Server.DomainObjects.Models;

namespace Sandbox.Server.DomainObjects.Interfaces.Repositories
{
  public interface IArticleRepository : IEntityRepository<Article>
  {
     Task<Article> RetrieveSingleBySlug(string slug);

     Task<IEnumerable<Article>> RetrieveByAuthor(string author);


     Task<IEnumerable<Article>> RetrieveByTag(string tag);
  }
}