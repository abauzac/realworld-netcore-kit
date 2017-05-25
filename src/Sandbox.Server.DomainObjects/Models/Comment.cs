using System;
using System.Collections.Generic;
using MongoDB.Bson;
using Sandbox.Server.DomainObjects.Models.Abstract;

namespace Sandbox.Server.DomainObjects.Models
{
    public class Comment : Entity
    {

        public string Body {get;set;}

        public User Author {get;set;}

        public Article Article {get;set;}
    }
}