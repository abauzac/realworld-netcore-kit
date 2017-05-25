using System;
using System.Collections.Generic;
using Sandbox.Server.DomainObjects.Models.Abstract;

namespace Sandbox.Server.DomainObjects.Models
{
    public class Article : Entity
    {
        public string Slug { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Body { get; set; }

        public List<String> TagList { get; set; }

        public User Author {get;set;}

        public List<Comment> Comments {get;set;}
    }
}