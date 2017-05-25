using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sandbox.Server.DomainObjects.Interfaces.Handlers;
using Sandbox.Server.DomainObjects.Interfaces.Handlers.Abstract;
using Sandbox.Server.DomainObjects.Models;
using Sandbox.Server.Http.WebApi.V1.Controllers.Abstract;
using Sandbox.Server.Http.WebApi.V1.Views.CommentViews;

namespace Sandbox.Server.Http.WebApi.V1.Controllers
{

    [Route("api")]
    public class CommentController : EntityController<Comment, IEntityHandler<Comment>>
    {
        public CommentController(ICommentHandler handler) : base(handler)
        {

        }

        [HttpGet]
        [Route("articles/{slug}/comments")]
        public Task<CommentView> GetAll(string slug){
            throw new NotImplementedException();
        }


        [HttpPost]
        [Route("articles/{slug}/comments")]
        public Task<CommentView> Create(string slug)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("articles/{slug}/comments/{commentId}")]
        public Task<CommentView> Delete(string slug, int commentId)
        {
            throw new NotImplementedException();
        }
    }
}