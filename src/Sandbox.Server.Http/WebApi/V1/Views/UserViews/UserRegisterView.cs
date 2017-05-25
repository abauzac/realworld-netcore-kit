using System;
using System.Collections.Generic;
using Sandbox.Server.DomainObjects.Models;
using Sandbox.Server.Http.WebApi.V1.Views.Abstract;

namespace Sandbox.Server.Http.WebApi.V1.Views.UserViews
{

    public class RootUserRegisterView
    {
        public UserRegisterView User { get; set; }
    }

    public class UserRegisterView : EntityView<User>
    {
        public UserRegisterView() : base()
        {
        }

        public UserRegisterView(User person) : base(person)
        {
        }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }


    }
}