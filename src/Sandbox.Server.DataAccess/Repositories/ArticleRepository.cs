using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Sandbox.Server.DataAccess.Repositories.Abstract;
using Sandbox.Server.DomainObjects.Interfaces.Repositories;
using Sandbox.Server.DomainObjects.Models;

namespace Sandbox.Server.DataAccess.Repositories
{
    public class ArticleRepository : EntityRepository<Article>, IArticleRepository
    {
        private IUserRepository _personRepository;

        public ArticleRepository(IUserRepository personRepository)
        {
            this._personRepository = personRepository;
        }

        public virtual async Task<Article> RetrieveSingleBySlug(string slug)
        {
            var filter = Builders<Article>.Filter.Eq("Slug", slug);

            var list = await collectionHandler.ReadOnly<Article>().FindAsync(filter);
            return await list.FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<Article>> RetrieveByAuthor(string author)
        {
            var filter = Builders<Article>.Filter.Where(x => x.Author.Username == author);
            var list = await collectionHandler.ReadOnly<Article>().FindAsync(filter);
            return await list.ToListAsync();
        }

        public virtual async Task<IEnumerable<Article>> RetrieveByTag(string tag)
        {
            var filter = Builders<Article>.Filter.Where(x => x.TagList.Contains(tag));
            var list = await collectionHandler.ReadOnly<Article>().FindAsync(filter);
            return await list.ToListAsync();
        }

        public virtual async Task<long> DeleteBySlug(string slug)
        {
            var result = await collectionHandler.Write<Article>().DeleteOneAsync(x => x.Slug.Equals(slug));
            return result.DeletedCount;
        }

        public virtual async Task<Article> UpdateForSlug(string slug, Article entity)
        {
            var filter = Builders<Article>.Filter.Where(x => x.Slug.Equals(slug));

            var res = await collectionHandler.Write<Article>()
                        .FindOneAndUpdateAsync(x => x.Slug.Equals(slug), entity.ToBsonDocument());

            return res;
        }
    }
}