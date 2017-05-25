using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Sandbox.Server.DomainObjects.Models;
using Sandbox.Server.Http.WebApi.V1.Views.Abstract;

namespace Sandbox.Server.Http.WebApi.V1.Views.ArticleViews
{
    public class ArticleView : EntityView<Article>
    {
        public ArticleView() : base()
        {
        }

        public ArticleView(Article model) : base(model)
        {
            this.CreatedAt = model.Id.CreationTime;
        }

        public string Slug { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Body { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public bool Favorited { get; set; }

        public List<string> TagList {get;set; } = new List<string>();

        public int FavoritesCount { get; set; }

        public User Author {get;set;}

    }
}