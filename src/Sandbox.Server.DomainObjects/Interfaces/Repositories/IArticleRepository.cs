using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Sandbox.Server.DomainObjects.Interfaces.Repositories.Abstract;
using Sandbox.Server.DomainObjects.Models;

namespace Sandbox.Server.DomainObjects.Interfaces.Repositories
{
    public interface IArticleRepository : IEntityRepository<Article>
    {
        Task<Article> RetrieveSingleBySlug(string slug);

        Task<IEnumerable<Article>> RetrieveByAuthor(string author);


        Task<IEnumerable<Article>> RetrieveByTag(string tag);

        Task<long> DeleteBySlug(string slug);

        Task<Article> UpdateForSlug(string slug, Article entity);
    }
}