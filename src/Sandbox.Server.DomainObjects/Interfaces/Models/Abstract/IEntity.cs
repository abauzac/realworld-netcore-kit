using System;
using MongoDB.Bson;

namespace Sandbox.Server.DomainObjects.Interfaces.Models.Abstract
{
    public interface IEntity : IModel
    {
        ObjectId Id { get; set; }

        DateTime UpdatedAt { get; set; }
    }
}