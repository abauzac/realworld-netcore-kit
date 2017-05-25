

using System;
using System.Collections.Generic;
using Sandbox.Server.DomainObjects.Models;
using Sandbox.Server.Http.WebApi.V1.Views.Abstract;
using Sandbox.Server.Http.WebApi.V1.Views.UserViews;

namespace Sandbox.Server.Http.WebApi.V1.Views.CommentViews
{
    public class RootCommentView
    {
        public CommentView Comment { get; set; }
    }

    public class CommentsView
    {
        public List<CommentView> Comments { get; set; }
    }


    public class CommentView : EntityView<Comment>
    {

        public CommentView(Comment comment) : base(comment)
        {
            this.CreatedAt = comment.Id.CreationTime;
        }

        public string Id { get; set; }

        public string Body { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public UserAuthView Author { get; set; }

    }
}