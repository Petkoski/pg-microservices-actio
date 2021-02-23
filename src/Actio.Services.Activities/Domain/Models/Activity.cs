using Actio.Common.Exceptions;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.Services.Activities.Domain.Models
{
    public class Activity
    {
        [BsonId]
        public Guid Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("category")]
        public string Category { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [BsonElement("userid")]
        public Guid UserId { get; set; }
        [BsonElement("createdat")]
        public DateTime CreatedAt { get; set; }

        protected Activity()
        {

        }

        public Activity(Guid id, 
            Category category, 
            Guid userId,
            string name,
            string description,
            DateTime createdAt)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ActioException("empty_activity_name", $"Activity name can not be empty.");
            }

            Id = id;
            Category = category.Name;
            UserId = userId;
            Name = name;
            Description = description;
            CreatedAt = createdAt;
        }
    }
}
