using System;
using System.Collections.Generic;
using MongoDB.Bson;
using Sandbox.Server.DomainObjects.Models;
using Sandbox.Server.Http.WebApi.V1.Views.Abstract;

namespace Sandbox.Server.Http.WebApi.V1.Views.UserViews
{
    public class RootUserAuthView
    {
        public UserAuthView User {get;set;}
    }

    public class UserAuthView : EntityView<User>
    {
        public UserAuthView() : base()
        {
        }

        public UserAuthView(User person) : base(person)
        {
        }

        public ObjectId Id { get; set; }
        
        public string Username { get; set; }
    
        public string Email { get; set; }

        public string Bio {get;set;}

        public string Image {get;set;}

        public string Token {get;set;}


    }
}