

using System;
using Sandbox.Server.DomainObjects.Models;
using Sandbox.Server.Http.WebApi.V1.Views.Abstract;
using Sandbox.Server.Http.WebApi.V1.Views.UserViews;

namespace Sandbox.Server.Http.WebApi.V1.Views.CommentViews{

    public class CommentView : EntityView<Comment>
    {

        public string Id { get; set; }

        public string Body { get; set; }

        public DateTime CreatedAd { get; set; }

        public DateTime UpdatedAt { get; set; }

        public UserAuthView Author { get; set; }

    }
}