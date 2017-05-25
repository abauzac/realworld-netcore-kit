using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sandbox.Server.DomainObjects.Interfaces.Handlers;
using Sandbox.Server.DomainObjects.Interfaces.Handlers.Abstract;
using Sandbox.Server.DomainObjects.Interfaces.Repositories;
using Sandbox.Server.DomainObjects.Models;
using Sandbox.Server.Http.WebApi.V1.Controllers.Abstract;
using Sandbox.Server.Http.WebApi.V1.Views.CommentViews;

namespace Sandbox.Server.Http.WebApi.V1.Controllers
{

    [Route("api")]
    public class CommentController : EntityController<Comment, IEntityHandler<Comment>>
    {
        private ICommentRepository repository;

        public CommentController(ICommentHandler handler, ICommentRepository repository) : base(handler)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("articles/{slug}/comments")]
        public async Task<CommentsView> GetAllForSlug(string slug)
        {
            var list = await this.repository.RetrieveAllForSlug(slug);
            var commentList = new CommentsView();
            // map domain objects to view objects
            commentList.Comments = list.Select(x => new CommentView(x)).ToList();
            return commentList;
        }


        [HttpPost]
        [Route("articles/{slug}/comments")]
        public async Task<RootCommentView> Create(string slug, [FromBody]RootCommentView comment)
        {
            var model = new Comment();
            comment.Comment.Hydrate(model);
            model.Article = new Article()
            {
                Slug = slug,
            };
            var created = await this.repository.Create(model);
            return new RootCommentView()
            {
                Comment = new CommentView(created)
            };
        }

        [HttpDelete]
        [Route("articles/{slug}/comments/{commentId}")]
        public Task<CommentView> Delete(string slug, int commentId)
        {
            throw new NotImplementedException();
        }
    }
}