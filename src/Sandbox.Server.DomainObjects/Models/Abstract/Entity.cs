using System;
using System.Linq;
using System.Reflection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Sandbox.Server.DomainObjects.Interfaces.Models.Abstract;

namespace Sandbox.Server.DomainObjects.Models.Abstract
{
    public abstract class Entity : Model, IEntity
    {
        private static readonly Random RandomGenerator;

        [BsonId]
        public ObjectId Id { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}