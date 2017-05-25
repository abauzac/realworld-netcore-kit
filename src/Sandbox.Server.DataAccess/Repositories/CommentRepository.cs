using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Sandbox.Server.DataAccess.Repositories.Abstract;
using Sandbox.Server.DomainObjects.Interfaces.Repositories;
using Sandbox.Server.DomainObjects.Models;

namespace Sandbox.Server.DataAccess.Repositories
{
    public class CommentRepository : EntityRepository<Comment>, ICommentRepository
    {
        public async Task<List<Comment>> RetrieveAllForSlug(string slug)
        {
            var filter = Builders<Comment>.Filter.Where(x => x.Article.Slug == slug);
            var list = await collectionHandler.ReadOnly<Comment>().FindAsync(filter);
            return await list.ToListAsync();
        }
    }
}