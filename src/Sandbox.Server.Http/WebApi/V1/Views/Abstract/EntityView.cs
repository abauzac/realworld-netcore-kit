using System;
using System.Linq;
using System.Reflection;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace Sandbox.Server.Http.WebApi.V1.Views.Abstract
{
    public abstract class EntityView<TE>
        where TE : Sandbox.Server.DomainObjects.Interfaces.Models.Abstract.IEntity
    {


        [JsonConverter(typeof(ObjectIdToStringJsonConverter))]
        public ObjectId Id { get; set; }

        public EntityView() : base()
        {
        }

        public EntityView(TE entity)
        {
            if (entity != null)
            {
                foreach (var propertyInfo in entity.GetType().GetProperties().ToArray())
                {
                    if (this.GetType().GetProperty(propertyInfo.Name) != null)
                    {
                        this.GetType().GetProperty(propertyInfo.Name).SetValue(this, propertyInfo.GetValue(entity, null));
                    }
                }
            }
        }

        public TE Hydrate(TE entity)
        {
            if (entity != null)
            {
                foreach (var propertyInfo in this.GetType().GetProperties().ToArray())
                {
                    if (entity.GetType().GetProperty(propertyInfo.Name) != null)
                    {
                        entity.GetType().GetProperty(propertyInfo.Name).SetValue(entity, propertyInfo.GetValue(this, null));
                    }
                }
            }

            return entity;
        }
    }


    internal class ObjectIdToStringJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return new ObjectId(existingValue as string);
        }

    }
}